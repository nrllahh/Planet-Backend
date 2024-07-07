using Planet.Domain.SharedKernel;

namespace Planet.Domain.Cards.DomainEvents
{
    public sealed class CardMovedDomainEvent : IDomainEvent
    {
        public Guid CardId { get; init; }
        public Guid OldListId { get; init; }
        public Guid NewListId { get; init; }
        public double OldOrder { get; init; }
        public double NewOrder { get; init; }

    }
}
