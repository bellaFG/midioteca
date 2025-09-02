using System.ComponentModel.DataAnnotations;
using static MidiotecaApi.Models.MediaConsumption;

namespace MidiotecaApi.Dtos
{
    public class MediaConsumptionCreateDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid MediaItemId { get; set; }

        public ConsumptionStatus Status { get; set; } = ConsumptionStatus.None;

        public DateTime? StartedAt { get; set; }

        public DateTime? FinishedAt { get; set; }

        public int? Rating { get; set; }

        public string? ReviewText { get; set; }

        public decimal? PricePaid { get; set; }

        public IFormFile? CustomCoverFile { get; set; }
    }
}
