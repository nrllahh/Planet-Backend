using FluentValidation;
using Planet.Domain.Resources.ValidationResources;

namespace Planet.Application.Features.Users.Commands.SignIn
{
    public class SignInCommandValidator : AbstractValidator<SignInCommand>
    {
        public SignInCommandValidator()
        {
            RuleFor(x => x.Email)
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .WithErrorCode(ValidationCodes.Email_NullOrWhiteSpace)
                .WithMessage(ValidationMessages.Email_NullOrWhiteSpace);

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithErrorCode(ValidationCodes.Email_Invalid)
                .WithMessage(ValidationMessages.Email_Invalid);

            RuleFor(x => x.Password)
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .WithErrorCode(ValidationCodes.Password_NullOrWhiteSpace)
                .WithMessage(ValidationMessages.Password_NullOrWhiteSpace);
        }
    }
}
