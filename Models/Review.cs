using System.ComponentModel.DataAnnotations;

namespace MidiotecaApi.Models
{
    /// <summary>
    /// Optional separate review entity (can be one-to-many with MediaConsumption)
    /// keeps review history if desired.
    /// </summary>
    public class Review : Entity
    {
        [Required]
        public Guid MediaConsumptionId { get; set; }
        public MediaConsumption? MediaConsumption { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        public string? Content { get; set; }

        public int? Rating { get; set; }
    }
}