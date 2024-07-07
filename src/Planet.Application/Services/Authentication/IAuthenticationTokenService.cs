using Planet.Application.Models.Authentication;
using System.Security.Claims;

namespace Planet.Application.Services.Authentication
{
    public interface IAuthenticationTokenService
    {
        TokenModel GenerateToken(IEnumerable<Claim> claims);
        IEnumerable<Claim> GetClaimsFromToken(string token);
    }
}
