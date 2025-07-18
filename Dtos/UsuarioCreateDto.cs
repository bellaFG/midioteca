using System.ComponentModel.DataAnnotations;

namespace Midioteca.Dtos
{
    public class UsuarioCreateDto
    {
        [Required]
        public required string Nome { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MinLength(6)]
        public required string Senha { get; set; }
    }
}
