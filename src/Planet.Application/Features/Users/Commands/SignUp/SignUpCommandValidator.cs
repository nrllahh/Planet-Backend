using FluentValidation;
using Planet.Domain.Resources.ValidationResources;
using Planet.Domain.Users;

namespace Planet.Application.Features.Users.Commands.SignUp
{
    public class SignUpCommandValidator : AbstractValidator<SignUpCommand>
    {
        public SignUpCommandValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage(ValidationMessages.Email_Invalid)
                .WithErrorCode(ValidationCodes.Email_Invalid);

            RuleFor(x => x.Email)
                .Length(Email.MinLength, Email.MaxLength)
                .WithMessage(string.Format(ValidationMessages.Email_InvalidLength, Email.MinLength, Email.MaxLength))
                .WithErrorCode(ValidationCodes.Email_InvalidLength);

            RuleFor(x => x.Password)
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .WithMessage(ValidationMessages.Password_NotMatch)
                .WithErrorCode(ValidationCodes.Password_NotMatch);

            RuleFor(x => x.Password)
                .Must((x, y) => y == x.PasswordConfirmation)
                .WithMessage(ValidationMessages.Password_NotMatch)
                .WithErrorCode(ValidationCodes.Password_NotMatch);

            RuleFor(x => x.FirstName)
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .WithMessage(ValidationMessages.FirstName_NullOrWhiteSpace)
                .WithErrorCode(ValidationCodes.FirstName_NullOrWhiteSpace);

            RuleFor(x => x.FirstName)
                .Length(FirstName.MinLength, FirstName.MaxLength)
                .WithMessage(string.Format(ValidationMessages.FirstName_InvalidLength, FirstName.MinLength, FirstName.MaxLength))
                .WithErrorCode(ValidationCodes.FirstName_InvalidLength);

            RuleFor(x => x.LastName)
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .WithMessage(ValidationMessages.LastName_NullOrWhiteSpace)
                .WithErrorCode(ValidationCodes.LastName_NullOrWhiteSpace);

            RuleFor(x => x.LastName)
                .Length(LastName.MinLength, LastName.MaxLength)
                .WithMessage(string.Format(ValidationMessages.LastName_InvalidLength, LastName.MinLength, LastName.MaxLength))
                .WithErrorCode(ValidationCodes.LastName_InvalidLength);

        }
    }
}
