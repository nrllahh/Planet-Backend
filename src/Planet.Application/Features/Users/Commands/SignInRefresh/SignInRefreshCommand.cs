using Planet.Application.Common;

namespace Planet.Application.Features.Users.Commands.SignInRefresh
{
    public class SignInRefreshCommand : CommandBase<SignInRefreshResponse>
    {
        public string AccessToken { get; init; }
        public string RefreshToken { get; init; }
    }
}
