using Planet.Domain.SharedKernel;

namespace Planet.Domain.Boards
{
    public record BoardDescription
    {
        public string Value { get; init; }

        private BoardDescription() { }

        private BoardDescription(string description)
        {
            Value = description;
        }

        public static BoardDescription Create(string description)
        {
            if (description.Length > 200)
            {
                throw new DomainException("BoardDescription.NotInRange", "Açıklama 200 karakterden uzun olamaz!");
            }

            return new BoardDescription(description);
        }
    }
}
