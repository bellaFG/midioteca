using System.ComponentModel.DataAnnotations;

namespace MidiotecaApi.Dtos
{
    public class UserUpdateDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public string? NewPassword { get; set; }
    }
}