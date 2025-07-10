using Midioteca.Services;
using Midioteca.Dtos;
using Midioteca.Models;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Midioteca.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioReadDto> CreateUsuarioAsync(UsuarioCreateDto dto);

        Task<UsuarioReadDto> GetUsuarioByIdAsync(Guid id);

        Task<IEnumerable<UsuarioReadDto>> GetAllUsuariosAsync();

        Task<UsuarioReadDto> UpdateUsuarioAsync(Guid id, UsuarioUpdateDto dto);

        Task DeleteUsuarioAsync(Guid id);
    }

}