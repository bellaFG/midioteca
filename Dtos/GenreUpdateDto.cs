using System.ComponentModel.DataAnnotations;

namespace MidiotecaApi.Dtos
{
    public class GenreUpdateDto
    {
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
