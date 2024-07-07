using Planet.Domain.SharedKernel;

namespace Planet.Domain.Cards.DomainEvents
{
    public sealed class CardTitleChangedDomainEvent : IDomainEvent
    {
        public Guid CardId { get; init; }
        public string Title { get; init; }
    }
}
