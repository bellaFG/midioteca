using MidiotecaApi.Models;

using System.ComponentModel.DataAnnotations;

namespace MidiotecaApi.Models
{
    /// <summary>
    /// Junction table for MediaItem <-> Genre (N:N).
    /// </summary>
    public class MediaItemGenre
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid MediaItemId { get; set; }
        public MediaItem? MediaItem { get; set; }

        [Required]
        public Guid GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}