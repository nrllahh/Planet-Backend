using Planet.Domain.SharedKernel;

namespace Planet.Domain.Cards
{
    public sealed class CardComment : Entity
    {
        public Guid UserId { get; private set; }
        public Guid CardId { get; private set; }
        public CardCommentContent Content { get; private set; }

        private CardComment() : base(Guid.Empty)
        {
        }
        private CardComment(
          Guid id,
          Guid userId,
          CardCommentContent content,
          Guid cardId) : base(id)
        {
            UserId = userId;
            Content = content;
            CardId = cardId;
        }
        public static CardComment Create(
           Guid id,
           Guid userId,
           CardCommentContent content,
           Guid cardId)
        {
            return new CardComment(id, userId, content, cardId);
        }


    }

}
