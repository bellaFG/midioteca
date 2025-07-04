using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MidiotecaWeb.Data;
using MidiotecaWeb.Dtos.Livro;
using MidiotecaWeb.Models;

namespace MidiotecaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly MidiotecaDbContext _context;
        private readonly IMapper _mapper;

        public LivrosController(MidiotecaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/Livros?titulo=texto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivroReadDto>>> GetLivros([FromQuery] string? titulo)
        {
            var query = _context.Livros
                .Include(l => l.Genero)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(titulo))
            {
                query = query.Where(l => l.Titulo.Contains(titulo));
            }

            var livros = await query.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<LivroReadDto>>(livros));
        }

        // GET: api/Livros/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<LivroReadDto>> GetLivro(Guid id)
        {
            var livro = await _context.Livros
                .Include(l => l.Genero)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (livro == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<LivroReadDto>(livro));
        }


        // POST: api/Livros
        [HttpPost]
        public async Task<ActionResult<LivroReadDto>> CreateLivro(LivroCreateDto livroDto)
        {
            var livro = _mapper.Map<Livro>(livroDto);

            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();

            var livroReadDto = _mapper.Map<LivroReadDto>(livro);

            return CreatedAtAction(nameof(GetLivro), new { id = livro.Id }, livroReadDto);
        }

        // PUT: api/Livros/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLivro(Guid id, LivroUpdateDto livroDto)
        {
            var livro = await _context.Livros.FindAsync(id);

            if (livro == null)
            {
                return NotFound();
            }

            _mapper.Map(livroDto, livro);

            _context.Entry(livro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Livros/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivro(Guid id)
        {
            var livro = await _context.Livros.FindAsync(id);

            if (livro == null)
            {
                return NotFound();
            }

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LivroExists(Guid id)
        {
            return _context.Livros.Any(e => e.Id == id);
        }
    }
}
