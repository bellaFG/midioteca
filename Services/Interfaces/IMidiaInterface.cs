using Midioteca.Dtos;
using Midioteca.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Midioteca.Services.Interfaces
{
    public interface IMidiaService
    {
        Task<Midia> CreateAsync(MidiaCreateDto dto, Guid usuarioId);
        Task<IEnumerable<Midia>> GetAllAsync(string? titulo, string? autor, string? diretor, int? ano);
        Task<Midia?> GetByIdAsync(Guid id);
        Task UpdateAsync(Guid id, MidiaUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}