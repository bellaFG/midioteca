using static MidiotecaApi.Models.MediaConsumption;

namespace MidiotecaApi.Dtos
{
    public class MediaConsumptionResponseDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public UserResponseDto? User { get; set; }

        public Guid MediaItemId { get; set; }

        public MediaResponseDto? Media { get; set; }

        public ConsumptionStatus Status { get; set; }

        public DateTime? StartedAt { get; set; }

        public DateTime? FinishedAt { get; set; }

        public int? Rating { get; set; }

        public string? Review { get; set; }

        public decimal? PricePaid { get; set; }

        public string? CustomCoverPath { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }

}
