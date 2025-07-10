using System.ComponentModel.DataAnnotations;

namespace Midioteca.Dtos
{
    public class UsuarioUpdateDto
    {

        public string? Nome { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? NovaSenha { get; set; }
    }
}