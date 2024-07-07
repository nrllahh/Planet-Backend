namespace Planet.Application.Models.Authentication
{
    public record TokenModel(
        string AccessToken,
        DateTime AccessTokenExpireDate,
        string RefreshToken,
        DateTime RefreshTokenExpireDate);
}
