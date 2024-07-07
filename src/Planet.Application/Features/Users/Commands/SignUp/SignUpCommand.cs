using Planet.Application.Common;

namespace Planet.Application.Features.Users.Commands.SignUp
{
    public sealed class SignUpCommand : CommandBase<SignUpResponse>
    {
        public string Email { get; init; }
        public string Password { get; init; }
        public string PasswordConfirmation { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }
}
