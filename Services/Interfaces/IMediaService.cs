using MidiotecaApi.Dtos;

namespace MidiotecaApi.Services.Interfaces
{
    public interface IMediaService
    {
        Task<IEnumerable<MediaResponseDto>> GetAllAsync();
        Task<MediaResponseDto?> GetByIdAsync(Guid id);
        Task<MediaResponseDto> CreateAsync(MediaCreateDto dto);
        Task<bool> UpdateAsync(Guid id, MediaUpdateDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
