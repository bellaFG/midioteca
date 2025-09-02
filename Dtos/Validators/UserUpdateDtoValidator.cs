using FluentValidation;

namespace MidiotecaApi.Dtos.Validators
{
    public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateDtoValidator()
        {
            RuleFor(u => u.Name)
                .MaximumLength(100).WithMessage("Name must be at most 100 characters.")
                .When(u => !string.IsNullOrWhiteSpace(u.Name));

            RuleFor(u => u.Email)
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(150).WithMessage("Email must be at most 150 characters.")
                .When(u => !string.IsNullOrWhiteSpace(u.Email));

            RuleFor(u => u.NewPassword)
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
                .When(u => !string.IsNullOrWhiteSpace(u.NewPassword));
        }
    }

}
