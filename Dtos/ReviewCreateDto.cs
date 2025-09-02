using System.ComponentModel.DataAnnotations;

namespace MidiotecaApi.Dtos
{
    public class ReviewCreateDto
    {
        [Required]
        public Guid MediaConsumptionId { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required, MaxLength(250)]
        public string Title { get; set; }

        public string? Content { get; set; }

        public int? Rating { get; set; }
    }
}
