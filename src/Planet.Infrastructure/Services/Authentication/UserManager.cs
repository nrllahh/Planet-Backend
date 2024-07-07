using IdentityModel;
using Microsoft.AspNetCore.Http;
using Planet.Application.Services.Authentication;

namespace Planet.Infrastructure.Services.Authentication
{
    public class UserManager : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetUserId()
        {
            string userId = _httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == JwtClaimTypes.Subject).Value;

            return Guid.Parse(userId);
        }
    }
}
