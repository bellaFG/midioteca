using Microsoft.AspNetCore.Mvc;
using MidiotecaApi.Dtos;
using MidiotecaApi.Services.Interfaces;

namespace MidiotecaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        /// <summary>
        /// Retorna todas as mídias cadastradas.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var medias = await _mediaService.GetAllAsync();
            return Ok(medias);
        }

        /// <summary>
        /// Retorna uma mídia pelo ID.
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var media = await _mediaService.GetByIdAsync(id);
            if (media == null)
                return NotFound();

            return Ok(media);
        }

        /// <summary>
        /// Cria uma nova mídia (Book ou Movie).
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MediaCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _mediaService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Atualiza uma mídia existente.
        /// </summary>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] MediaUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _mediaService.UpdateAsync(id, dto);
            if (!updated)
                return NotFound();

            return NoContent(); // 204: atualizado com sucesso, sem corpo
        }

        /// <summary>
        /// Exclui uma mídia pelo ID.
        /// </summary>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _mediaService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
