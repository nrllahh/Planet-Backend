using Planet.Application.Common;

namespace Planet.Application.Features.Users.Commands.SignIn
{
    public class SignInCommand : CommandBase<SignInResponse>
    {
        public string Email { get; init; }
        public string Password { get; init; }
    }
}
