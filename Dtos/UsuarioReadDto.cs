using Midioteca.Models;

namespace Midioteca.Dtos
{
    public class UsuarioReadDto
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }

    }
}