using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Midioteca.Data;
using Midioteca.Dtos.Livro;
using Midioteca.Models;

namespace Midioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroService _service;

        public LivrosController(ILivroService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPorId(Guid id)
        {
            var livro = await _service.GetLivroPorId(id);
            return Ok(livro);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] LivroFiltroDto filtro)
        {
            var livros = await _service.GetLivros(filtro);
            return Ok(livros);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LivroCreateDto dto)
        {
            var livro = await _service.CriarLivro(dto);
            return CreatedAtAction(nameof(GetPorId), new { id = livro.Id }, livro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] LivroUpdateDto dto)
        {
            await _service.AtualizarLivro(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeletarLivro(id);
            return NoContent();
        }
    }
}

