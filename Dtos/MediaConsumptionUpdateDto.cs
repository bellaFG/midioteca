using static MidiotecaApi.Models.MediaConsumption;

namespace MidiotecaApi.Dtos
{
    public class MediaConsumptionUpdateDto
    {
        public ConsumptionStatus Status { get; set; }

        public DateTime? StartedAt { get; set; }

        public DateTime? FinishedAt { get; set; }

        public int? Rating { get; set; }

        public string? ReviewText { get; set; }

        public decimal? PricePaid { get; set; }

        public IFormFile? CustomCoverFile { get; set; }
    }
}
