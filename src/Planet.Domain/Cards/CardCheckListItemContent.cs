using Planet.Domain.SharedKernel;

namespace Planet.Domain.Cards
{
    public record CardCheckListItemContent
    {
        public string Value { get; init; }
        private CardCheckListItemContent() { }
        private CardCheckListItemContent(string content)
        {
            Value = content;
        }
        public static CardCheckListItemContent Create(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new DomainException("ItemContent.NullOrWhiteSpace", "Eklenecek olan öğe boş olamaz!");
            }
            if (content.Length > 200)
            {
                throw new DomainException("ItemContent.NotInRange", "Öğe 200 karakterden fazla olamaz!");
            }
            return new CardCheckListItemContent(content);
        }
    }
}
