using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Planet.Application.Models.Authentication;
using Planet.Application.Services.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Planet.Infrastructure.Services.Authentication
{
    public class JwtTokenManager : IAuthenticationTokenService
    {
        private readonly IConfiguration _configuration;

        public JwtTokenManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenModel GenerateToken(IEnumerable<Claim> claims)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]));

            var now = DateTime.Now;

            int minutes = int.Parse(_configuration["Jwt:Minutes"]);
            int refreshMinutes = int.Parse(_configuration["Jwt:RefreshMinutes"]);

            var expireDate = now.Add(TimeSpan.FromMinutes(minutes));
            var refreshExpireDate = now.Add(TimeSpan.FromMinutes(refreshMinutes));

            var jwt = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    claims: claims,
                    notBefore: now,
                    expires: expireDate,
                    signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                );

            return new TokenModel(
                new JwtSecurityTokenHandler().WriteToken(jwt),
                expireDate,
                GetRefreshToken(),
                refreshExpireDate
                );
        }

        public IEnumerable<Claim> GetClaimsFromToken(string token)
        {
            try
            {
                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]));
                var jwtHandler = new JwtSecurityTokenHandler();
                var jwt = jwtHandler.ReadJwtToken(token);

                return jwt.Claims;
            }
            catch
            {
                return null;
            }
        }

        private string GetRefreshToken()
        {
            using var rng = RandomNumberGenerator.Create();
            byte[] bytes = new byte[16];
            rng.GetBytes(bytes);

            return Convert.ToBase64String(bytes);
        }
    }
}
