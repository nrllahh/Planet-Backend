using IdentityModel;
using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;
using Planet.Domain.Users;
using System.Security.Claims;

namespace Planet.Application.Features.Users.Commands.SignInRefresh
{
    internal class SignInRefreshCommandHandler : RequestHandlerBase<SignInRefreshCommand, SignInRefreshResponse>
    {
        private readonly IAuthenticationTokenService _authenticationTokenService;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public SignInRefreshCommandHandler(IAuthenticationTokenService authenticationTokenService, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _authenticationTokenService = authenticationTokenService;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public override async Task<SignInRefreshResponse> Handle(SignInRefreshCommand request, CancellationToken cancellationToken)
        {
            var userId = _authenticationTokenService.GetClaimsFromToken(request.AccessToken).First(a => a.Type == JwtClaimTypes.Subject).Value;
            var user = await _userRepository.FindAsync(Guid.Parse(userId));

            if (IsTokenExpired(user))
            {
                return Response.Failure<SignInRefreshResponse>(OperationMessages.RefreshTokenExpired);
            }

            if (request.RefreshToken != user.RefreshToken)
            {
                return Response.Failure<SignInRefreshResponse>(OperationMessages.RefreshTokenInvalid);
            }

            var tokenModel = _authenticationTokenService.GenerateToken(GetClaims(user));
            user.SignIn(tokenModel.RefreshToken, tokenModel.RefreshTokenExpireDate);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Response.SuccessWithBody<SignInRefreshResponse>(tokenModel, OperationMessages.SignedInWithRefreshTokenSuccessfully);
        }

        private List<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Subject, user.Id.ToString()),
                new Claim(JwtClaimTypes.Name, $"{user.FirstName.Value} {user.LastName.Value}"),
                new Claim(JwtClaimTypes.Email, user.Email.Value),
            };

            return claims;
        }

        private bool IsTokenExpired(User user)
        {
            return !user.TokenExpireDate.HasValue || user.TokenExpireDate < DateTime.Now;
        }
    }
}
