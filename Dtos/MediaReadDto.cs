using Microsoft.AspNetCore.Mvc.Formatters;

namespace MidiotecaApi.Dtos
{
    public class MediaReadDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public MediaType Type { get; set; }

        public List<string> Genres { get; set; } = new();

        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public int? PublicationYear { get; set; }
        public int? Pages { get; set; }

        public string? Director { get; set; }
        public int? ReleaseYear { get; set; }
        public int? Duration { get; set; }

        public string? CoverPath { get; set; }
    }
}
