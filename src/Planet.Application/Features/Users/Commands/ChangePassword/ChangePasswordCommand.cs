using Planet.Application.Common;

namespace Planet.Application.Features.Users.Commands.ChangePassword
{
    public class ChangePasswordCommand : CommandBase<ChangePasswordResponse>
    {
        public string OldPassword { get; init; }
        public string Password { get; init; }
        public string PasswordConfirmation { get; init; }
    }

}
