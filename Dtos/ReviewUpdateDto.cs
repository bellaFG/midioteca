using System.ComponentModel.DataAnnotations;

namespace MidiotecaApi.Dtos
{
    public class ReviewUpdateDto
    {
        [Required, MaxLength(250)]
        public string Title { get; set; }

        public string? Content { get; set; }

        public int? Rating { get; set; }
    }

}
