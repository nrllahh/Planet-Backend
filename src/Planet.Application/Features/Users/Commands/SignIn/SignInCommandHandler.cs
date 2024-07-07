using IdentityModel;
using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Cryptography;
using Planet.Application.Services.Repositories;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;
using Planet.Domain.Users;
using System.Security.Claims;

namespace Planet.Application.Features.Users.Commands.SignIn
{
    internal class SignInCommandHandler : RequestHandlerBase<SignInCommand, SignInResponse>
    {
        private readonly ICryptographyService _cryptographyService;
        private readonly IAuthenticationTokenService _authenticationTokenService;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SignInCommandHandler(ICryptographyService cryptographyService, IAuthenticationTokenService authenticationTokenService, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _cryptographyService = cryptographyService;
            _authenticationTokenService = authenticationTokenService;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public override async Task<SignInResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByEmailAsync(request.Email);

            if (user is null)
            {
                return Response.Failure<SignInResponse>(OperationMessages.EmailNotFound);
            }

            bool isVerified = _cryptographyService.VerifyPassword(request.Password, user.Salt, user.Password);

            if (!isVerified)
            {
                return Response.Failure<SignInResponse>(OperationMessages.WrongEmailOrPassword);
            }

            var tokenModel = _authenticationTokenService.GenerateToken(GetClaims(user));
            user.SignIn(tokenModel.RefreshToken, tokenModel.RefreshTokenExpireDate);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Response.SuccessWithBody<SignInResponse>(tokenModel, OperationMessages.SignedInSuccessfully);
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
    }
}
