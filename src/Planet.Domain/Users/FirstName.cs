using Planet.Domain.SharedKernel;

namespace Planet.Domain.Users
{
    public record FirstName
    {
        public const int MaxLength = 50;
        public const int MinLength = 2;

        public string Value { get; init; }

        private FirstName() { }

        private FirstName(string firstName)
        {
            Value = firstName;
        }

        public static FirstName Create(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new DomainException("FirstName.NullOrWhiteSpace", "İsim boş olamaz!");
            }

            if (firstName.Length < 2 || firstName.Length > 50)
            {
                throw new DomainException("FirstName.NotInRange", "İsim uzunluğu belirtilen aralıkta değil! ([2-50])");
            }

            //if (!firstName.All(c => char.IsLetter(c)))
            //{
            //    throw new DomainException("FirstName.InvalidChar", "İsim uygunsuz karakterler içeriyor!");
            //}

            return new FirstName(firstName);
        }
    }
}
