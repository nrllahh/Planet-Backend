using Planet.Domain.SharedKernel;

namespace Planet.Domain.Cards
{
    public record CardDescription
    {
        public string Value { get; init; }

        private CardDescription() { }
        private CardDescription(string description)
        {
            Value = description;
        }
        public static CardDescription Create(string description)
        {
            if (description.Length > 200)
            {
                throw new DomainException("CardDescription.NotInRange", "Açıklama 200 karakterden uzun olamaz!");
            }
            return new CardDescription(description);
        }
    }
}
