using System.ComponentModel.DataAnnotations;

namespace MidiotecaApi.Models
{
    /// <summary>
    /// Generic media item (book, movie, ...).
    /// Shared fields go here.
    /// </summary>
    public abstract class MediaItem : Entity
    {
        [Required]
        [MaxLength(300)]
        public string Title { get; set; }

        public string? Description { get; set; }


        [MaxLength(200)]
        public string? ExternalId { get; set; }
        public string? ExternalCoverUrl { get; set; }
        public bool IsFromExternal { get; set; } = false;


        public string? CustomCoverPath { get; set; }

        public MediaType Type { get; set; }

        public virtual ICollection<MediaItemGenre> MediaItemGenres { get; set; } = new List<MediaItemGenre>();
        public virtual ICollection<MediaConsumption> MediaConsumptions { get; set; } = new List<MediaConsumption>();

        public enum MediaType
        {
            Book = 0,
            Movie = 1
        }
    }
}