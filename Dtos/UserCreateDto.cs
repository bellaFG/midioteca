using System.ComponentModel.DataAnnotations;

namespace MidiotecaApi.Dtos
{
    // DTO para criação de usuário (recebendo senha em texto)
    public class UserCreateDto
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
