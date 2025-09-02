using FluentValidation;
using MidiotecaApi.Models;

namespace MidiotecaApi.Dtos.Validators
{
    public class MediaUpdateDtoValidator : AbstractValidator<MediaUpdateDto>
    {
        public MediaUpdateDtoValidator()
        {
            RuleFor(x => x.Type)
                .IsInEnum().When(x => x.Type.HasValue)
                .WithMessage("Invalid media type.");

            When(x => x.Type == MediaItem.MediaType.Book, () =>
            {
                RuleFor(x => x.Author)
                    .NotEmpty().WithMessage("Author is required for books.");
                RuleFor(x => x.Publisher)
                    .NotEmpty().WithMessage("Publisher is required for books.");
            });

            When(x => x.Type == MediaItem.MediaType.Movie, () =>
            {
                RuleFor(x => x.Director)
                    .NotEmpty().WithMessage("Director is required for movies.");
            });

            When(x => x.IsFromExternal == true, () =>
            {
                RuleFor(x => x.ExternalId)
                    .NotEmpty().WithMessage("ExternalId is required when IsFromExternal is true.");
            });
        }
    }
}