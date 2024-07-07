using Planet.Domain.SharedKernel;

namespace Planet.Domain.Cards
{
    public record CardTitle
    {
        public string Value { get; init; }

        private CardTitle() { }

        private CardTitle(string title)
        {
            Value = title;
        }

        public static CardTitle Create(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new DomainException("CardTitle.NullOrWhiteSpace", "Başlık boş olamaz!");
            }
            if (title.Length > 100)
            {
                throw new DomainException("CardTitle.NotInRange", "Başlık 100 karakterden fazla olamaz!");
            }

            return new CardTitle(title);
        }
    }
}
