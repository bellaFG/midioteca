using Microsoft.AspNetCore.Mvc;
using Midioteca.Dtos;
using Midioteca.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Midioteca.Controllers
{

    [ApiController]
    [Route("api/midias")]
    public class MidiaController : ControllerBase
    {
        private readonly IMidiaService _service;

        public MidiaController(IMidiaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MidiaCreateDto dto, [FromQuery] Guid usuarioId)
        {
            var midia = await _service.CreateAsync(dto, usuarioId);
            return CreatedAtAction(nameof(GetById), new { id = midia.Id }, midia);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? titulo, [FromQuery] string? autor, [FromQuery] string? diretor, [FromQuery] int? ano)
        {
            var midias = await _service.GetAllAsync(titulo, autor, diretor, ano);
            return Ok(midias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var midia = await _service.GetByIdAsync(id);
            if (midia == null) return NotFound();
            return Ok(midia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] MidiaUpdateDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}