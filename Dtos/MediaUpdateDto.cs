using static MidiotecaApi.Models.MediaItem;

namespace MidiotecaApi.Dtos
{
    public class MediaUpdateDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<Guid>? GenreIds { get; set; }

        public string? ExternalId { get; set; }
        public string? ExternalCoverUrl { get; set; }
        public bool? IsFromExternal { get; set; }

        public string? CustomCoverPath { get; set; }

        public MediaType? Type { get; set; }

        // Campos específicos de livro
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public int? PublicationYear { get; set; }
        public int? Pages { get; set; }

        // Campos específicos de filme
        public string? Director { get; set; }
        public int? ReleaseYear { get; set; }
        public int? DurationMinutes { get; set; }
    }
}