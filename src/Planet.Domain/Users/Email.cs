using Planet.Domain.Resources.ValidationResources;
using Planet.Domain.SharedKernel;
using System.Text.RegularExpressions;

namespace Planet.Domain.Users
{
    public record Email
    {
        public const int MaxLength = 250;
        public const int MinLength = 5;

        public string Value { get; init; }

        private Email(string email)
        {
            Value = email;
        }

        private Email() { }

        public static Email Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new DomainException(ValidationCodes.Email_NullOrWhiteSpace, ValidationMessages.Email_NullOrWhiteSpace);
            }

            if (!IsValidEmail(email))
            {
                throw new DomainException(ValidationCodes.Email_Invalid, ValidationMessages.Email_Invalid);
            }

            if (!IsInRange(email))
            {
                throw new DomainException(ValidationCodes.Email_InvalidLength,
                    string.Format(ValidationMessages.Email_InvalidLength, MinLength, MaxLength));
            }

            return new Email(email);
        }

        private static bool IsInRange(string email)
        {
            return email.Length <= MaxLength && email.Length >= MinLength;
        }

        private static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        }

    }
}
