using FluentValidation;
using MidiotecaApi.Models;

namespace MidiotecaApi.Dtos.Validators
{

    public class MediaCreateDtoValidator : AbstractValidator<MediaCreateDto>
    {
        public MediaCreateDtoValidator()
        {
            // Comuns a qualquer mídia
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title must be at most 200 characters.");

            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("Invalid media type.");

            RuleFor(x => x.GenreIds)
                .NotEmpty().WithMessage("At least one genre is required.")
                .Must(ids => ids.All(id => id != Guid.Empty))
                .WithMessage("Invalid genre id.");


            // Validações específicas por tipo
            When(x => x.Type == MediaItem.MediaType.Book, () =>
            {
                RuleFor(x => x.Author)
                    .NotEmpty().WithMessage("Author is required for books.");
                RuleFor(x => x.Publisher)
                    .NotEmpty().WithMessage("Publisher is required for books.");
                RuleFor(x => x.PublicationYear)
                    .NotNull().WithMessage("PublicationYear is required for books.")
                    .InclusiveBetween(1450, DateTime.UtcNow.Year)
                    .WithMessage($"PublicationYear must be between 1450 and {DateTime.UtcNow.Year}.");
            });

            When(x => x.Type == MediaItem.MediaType.Movie, () =>
            {
                RuleFor(x => x.Director)
                    .NotEmpty().WithMessage("Director is required for movies.");
                RuleFor(x => x.ReleaseYear)
                    .NotNull().WithMessage("ReleaseYear is required for movies.")
                    .InclusiveBetween(1888, DateTime.UtcNow.Year)
                    .WithMessage($"ReleaseYear must be between 1888 and {DateTime.UtcNow.Year}.");
            });

            // Validação para URLs externas
            When(x => x.IsFromExternal, () =>
            {
                RuleFor(x => x.ExternalId)
                    .NotEmpty().WithMessage("ExternalId is required when IsFromExternal is true.");
                RuleFor(x => x.ExternalCoverUrl)
                    .NotEmpty().WithMessage("ExternalCoverUrl is required when IsFromExternal is true.");
            });
        }
    }

}
