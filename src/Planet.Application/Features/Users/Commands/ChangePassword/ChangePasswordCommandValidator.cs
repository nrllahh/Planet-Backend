using FluentValidation;
using Planet.Domain.Resources.ValidationResources;

namespace Planet.Application.Features.Users.Commands.ChangePassword
{
    public sealed class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(x => x.OldPassword)
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .WithErrorCode(ValidationCodes.Password_NullOrWhiteSpace)
                .WithMessage(ValidationMessages.Password_NullOrWhiteSpace);

            RuleFor(x => x.Password)
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .WithErrorCode(ValidationCodes.Password_NullOrWhiteSpace)
                .WithMessage(ValidationCodes.Password_NullOrWhiteSpace);

            RuleFor(x => x.Password)
                .Must((y, x) => y.PasswordConfirmation == x)
                .WithErrorCode(ValidationCodes.Password_NotMatch)
                .WithMessage(ValidationMessages.Password_NotMatch);
        }
    }
}
