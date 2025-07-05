using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Midioteca.Data;
using Midioteca.Models;
using Midioteca.Dtos.Livro;

public class LivroService : ILivroService
{
    private readonly MidiotecaDbContext _context;
    private readonly IMapper _mapper;

    public LivroService(MidiotecaDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<LivroReadDto> GetLivroPorId(Guid id)
    {
        var livro = await _context.Livros.Include(l => l.Genero)
            .FirstOrDefaultAsync(l => l.Id == id);

        if (livro == null)
            throw new KeyNotFoundException("Livro não encontrado.");

        return _mapper.Map<LivroReadDto>(livro);
    }

    public async Task<PagedResult<LivroReadDto>> GetLivros(LivroFiltroDto filtro)
    {
        var query = _context.Livros.Include(l => l.Genero).AsQueryable();

        if (!string.IsNullOrWhiteSpace(filtro.Titulo))
            query = query.Where(l => l.Titulo.Contains(filtro.Titulo));

        if (!string.IsNullOrWhiteSpace(filtro.Genero))
            query = query.Where(l => l.Genero.Nome.Contains(filtro.Genero));

        if (filtro.AnoPublicacao.HasValue)
            query = query.Where(l => l.AnoPublicacao == filtro.AnoPublicacao.Value);

        var totalCount = await query.CountAsync();

        var livros = await query
            .Skip((filtro.Pagina - 1) * filtro.TamanhoPagina)
            .Take(filtro.TamanhoPagina)
            .ToListAsync();

        return new PagedResult<LivroReadDto>
        {
            Items = _mapper.Map<IEnumerable<LivroReadDto>>(livros),
            TotalCount = totalCount
        };
    }

    public async Task<LivroReadDto> CriarLivro(LivroCreateDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Titulo) || string.IsNullOrWhiteSpace(dto.Autor))
            throw new ArgumentException("Título e Autor são obrigatórios.");

        var generoExiste = await _context.Generos.AnyAsync(g => g.Id == dto.GeneroId);
        if (!generoExiste)
            throw new ArgumentException("Gênero inválido.");

        var livro = _mapper.Map<Livro>(dto);

        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();

        return _mapper.Map<LivroReadDto>(livro);
    }

    public async Task AtualizarLivro(Guid id, LivroUpdateDto dto)
    {
        var livro = await _context.Livros.FindAsync(id);

        if (livro == null)
            throw new KeyNotFoundException("Livro não encontrado.");

        _mapper.Map(dto, livro);
        await _context.SaveChangesAsync();
    }

    public async Task DeletarLivro(Guid id)
    {
        var livro = await _context.Livros.FindAsync(id);

        if (livro == null)
            throw new KeyNotFoundException("Livro não encontrado.");

        _context.Livros.Remove(livro);
        await _context.SaveChangesAsync();
    }
}
