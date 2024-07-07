namespace Planet.Application.Services.Cryptography
{
    public interface ICryptographyService
    {
        (string, string) HashPassword(string password);
        bool VerifyPassword(string password, string salt, string hashedPassword);
        string GenerateRandomString();
        string GenerateUrlSafeRandomString();
        byte[] Encrypt(string key, string plainText);
        byte[] Decrypt(string key, byte[] cipher);
    }
}
