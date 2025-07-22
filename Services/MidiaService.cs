using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Midioteca.Data;
using Midioteca.Dtos;
using Midioteca.Models;
using Midioteca.Services.Interfaces;

namespace Midioteca.Services
{
    public class MidiaService : IMidiaService
    {
        private readonly MidiotecaDbContext _context;

        public MidiaService(MidiotecaDbContext context)
        {
            _context = context;
        }

        public async Task<Midia> CreateAsync(MidiaCreateDto dto, Guid usuarioId)
        {
            if (string.IsNullOrWhiteSpace(dto.Titulo))
                throw new ArgumentException("O título é obrigatório.");

            if (!Enum.IsDefined(typeof(TipoMidia), dto.Tipo))
                throw new ArgumentException("Tipo inválido.");

            var tipo = (TipoMidia)dto.Tipo;

            Midia midia;

            if (tipo == TipoMidia.Livro)
            {
                if (string.IsNullOrWhiteSpace(dto.Autor))
                    throw new ArgumentException("O autor é obrigatório para livros.");

                midia = new Livro
                {
                    Titulo = dto.Titulo,
                    GeneroId = dto.GeneroId,
                    TipoMidia = TipoMidia.Livro,
                    Autor = dto.Autor,
                    Editora = dto.Editora,
                    AnoPublicacao = dto.AnoPublicacao ?? 0,
                    Paginas = dto.Paginas
                };
            }
            else if (tipo == TipoMidia.Filme)
            {
                if (string.IsNullOrWhiteSpace(dto.Diretor))
                    throw new ArgumentException("O diretor é obrigatório para filmes.");

                midia = new Filme
                {
                    Titulo = dto.Titulo,
                    GeneroId = dto.GeneroId,
                    TipoMidia = TipoMidia.Filme,
                    Diretor = dto.Diretor,
                    AnoLancamento = dto.AnoLancamento ?? 0,
                    Duracao = dto.Duracao
                };
            }
            else
            {
                throw new ArgumentException("Tipo de mídia não suportado.");
            }

            _context.Midias.Add(midia);

            _context.ConsumosMidia.Add(new ConsumoMidia
            {
                UsuarioId = usuarioId,
                Midia = midia
            });

            await _context.SaveChangesAsync();

            return midia;
        }

        public async Task<IEnumerable<Midia>> GetAllAsync(string? titulo, string? autor, string? diretor, int? ano)
        {
            var query = _context.Midias.AsQueryable();

            if (!string.IsNullOrWhiteSpace(titulo))
                query = query.Where(m => m.Titulo.Contains(titulo));

            if (!string.IsNullOrWhiteSpace(autor))
                query = query.OfType<Livro>().Where(l => l.Autor.Contains(autor));

            if (!string.IsNullOrWhiteSpace(diretor))
                query = query.OfType<Filme>().Where(f => f.Diretor.Contains(diretor));

            if (ano.HasValue)
            {
                query = query.Where(m =>
                    (m is Livro && ((Livro)m).AnoPublicacao == ano.Value) ||
                    (m is Filme && ((Filme)m).AnoLancamento == ano.Value));
            }

            return await query.ToListAsync();
        }

        public async Task<Midia?> GetByIdAsync(Guid id)
        {
            var midia = await _context.Midias.FindAsync(id);

            if (midia == null)
                throw new KeyNotFoundException($"Nenhuma mídia encontrada com ID: {id}");

            return midia;
        }

        public async Task UpdateAsync(Guid id, MidiaUpdateDto dto)
        {
            var midia = await _context.Midias.FindAsync(id);

            if (midia == null)
                throw new KeyNotFoundException($"Nenhuma mídia encontrada com ID: {id}");

            if (!string.IsNullOrWhiteSpace(dto.Titulo))
                midia.Titulo = dto.Titulo;

            if (dto.GeneroId.HasValue)
                midia.GeneroId = dto.GeneroId.Value;

            switch (midia)
            {
                case Livro livro:
                    if (!string.IsNullOrWhiteSpace(dto.Autor)) livro.Autor = dto.Autor;
                    if (!string.IsNullOrWhiteSpace(dto.Editora)) livro.Editora = dto.Editora;
                    if (dto.AnoPublicacao.HasValue) livro.AnoPublicacao = dto.AnoPublicacao.Value;
                    if (dto.Paginas.HasValue) livro.Paginas = dto.Paginas.Value;
                    break;

                case Filme filme:
                    if (!string.IsNullOrWhiteSpace(dto.Diretor)) filme.Diretor = dto.Diretor;
                    if (dto.AnoLancamento.HasValue) filme.AnoLancamento = dto.AnoLancamento.Value;
                    if (dto.Duracao.HasValue) filme.Duracao = dto.Duracao.Value;
                    break;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var midia = await _context.Midias.FindAsync(id);

            if (midia == null)
                throw new KeyNotFoundException($"Nenhuma mídia encontrada com ID: {id}");

            _context.Midias.Remove(midia);

            await _context.SaveChangesAsync();
        }
    }
}
