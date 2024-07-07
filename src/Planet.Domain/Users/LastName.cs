using Planet.Domain.SharedKernel;

namespace Planet.Domain.Users
{
    public record LastName
    {
        public const int MaxLength = 50;
        public const int MinLength = 2;
        public string Value { get; init; }

        private LastName() { }

        private LastName(string lastName)
        {
            Value = lastName;
        }

        public static LastName Create(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new DomainException("LastName.NullOrWhiteSpace", "İsim boş olamaz!");
            }

            if (lastName.Length < 2 || lastName.Length > 50)
            {
                throw new DomainException("LastName.NotInRange", "İsim uzunluğu belirtilen aralıkta değil! ([2-50])");
            }

            //if (!lastName.All(c => char.IsLetter(c)))
            //{
            //    throw new DomainException("LastName.InvalidChar", "İsim uygunsuz karakterler içeriyor!");
            //}

            return new LastName(lastName);
        }
    }
}
