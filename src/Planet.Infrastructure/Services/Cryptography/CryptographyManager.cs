using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Planet.Application.Services.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace Planet.Infrastructure.Services.Cryptography
{
    public class CryptographyManager : ICryptographyService
    {
        public (string, string) HashPassword(string password)
        {
            byte[] saltBytes = GenerateSalt();
            string salt = Convert.ToBase64String(saltBytes);
            string hashed = Hash(password, saltBytes);

            return (hashed, salt);
        }


        public bool VerifyPassword(string password, string salt, string hashedPassword)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            return hashedPassword == Hash(password, saltBytes);
        }

        public string GenerateRandomString()
        {
            return Convert.ToBase64String(GenerateSalt());
        }

        public string GenerateUrlSafeRandomString()
        {
            string str = GenerateRandomString();

            return str.Replace("+", "").Replace("=", "").Replace("/", "");
        }

        private string Hash(string password, byte[] saltBytes)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                            password: password,
                            salt: saltBytes,
                            prf: KeyDerivationPrf.HMACSHA256,
                            iterationCount: 10000,
                            numBytesRequested: 256 / 8));
        }

        private byte[] GenerateSalt()
        {
            using var rng = RandomNumberGenerator.Create();

            byte[] bytes = new byte[16];
            rng.GetBytes(bytes);

            return bytes;
        }

        public byte[] Encrypt(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return array;
        }

        public byte[] Decrypt(string key, byte[] cipher)
        {
            byte[] iv = new byte[16];
            byte[] buffer = cipher;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var outputStream = new MemoryStream())
                        {
                            cryptoStream.CopyTo(outputStream);

                            return outputStream.ToArray();
                        }
                    }
                }
            }
        }
    }
}
