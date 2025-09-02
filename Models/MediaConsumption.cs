using System.ComponentModel.DataAnnotations;

namespace MidiotecaApi.Models
{
    /// <summary>
    /// Represents a user's personal record for a media item:
    /// status, rating, dates, optional custom cover, price paid, etc.
    /// </summary>
    public class MediaConsumption : Entity
    {
        [Required]
        public Guid UserId { get; set; }
        public User? User { get; set; }

        [Required]
        public Guid MediaItemId { get; set; }
        public MediaItem? MediaItem { get; set; }

        public ConsumptionStatus Status { get; set; } = ConsumptionStatus.None;

        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }

        public int? Rating { get; set; } // 1..10, nullable

        public string? ReviewText { get; set; } // short personal note (redundant with Review model if you want separation)

        public decimal? PricePaid { get; set; } // financial information

        public string? CustomCoverPath { get; set; }

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        public enum ConsumptionStatus
        {
            None = 0,
            WantToConsume = 1,
            Consuming = 2,
            Consumed = 3,
            Abandoned = 4
        }
    }
}