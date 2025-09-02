using static MidiotecaApi.Models.MediaItem;

namespace MidiotecaApi.Dtos
{
    public class MediaResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? GenreName { get; set; }
        public MediaType Type { get; set; }

        public bool IsFromExternal { get; set; }
        public string? ExternalId { get; set; }
        public string? ExternalCoverUrl { get; set; }

        public string? CustomCoverPath { get; set; }

        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public int? PublicationYear { get; set; }
        public int? Pages { get; set; }
        public string? Director { get; set; }
        public int? ReleaseYear { get; set; }
        public int? DurationMinutes { get; set; }
    }
}