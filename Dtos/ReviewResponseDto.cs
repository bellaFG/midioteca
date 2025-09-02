namespace MidiotecaApi.Dtos
{
    public class ReviewResponseDto
    {
        public Guid Id { get; set; }

        public Guid MediaConsumptionId { get; set; }

        public Guid AuthorId { get; set; }

        public UserResponseDto? Author { get; set; }

        public string Title { get; set; }

        public string? Content { get; set; }

        public int? Rating { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
