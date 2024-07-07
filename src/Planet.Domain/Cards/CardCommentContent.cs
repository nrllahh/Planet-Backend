using Planet.Domain.SharedKernel;

namespace Planet.Domain.Cards
{
    public record CardCommentContent
    {
        public string Value { get; init; }

        private CardCommentContent() { }
        private CardCommentContent(string description)
        {
            Value = description;
        }
        public static CardCommentContent Create(string description)
        {
            if (description.Length > 200)
            {
                throw new DomainException("CommentContent.NotInRange", "Açıklama 200 karakterden uzun olamaz!");
            }
            return new CardCommentContent(description);
        }
    }
}
