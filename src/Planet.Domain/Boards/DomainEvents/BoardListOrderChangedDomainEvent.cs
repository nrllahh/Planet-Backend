using Planet.Domain.SharedKernel;

namespace Planet.Domain.Boards.DomainEvents
{
    public sealed class BoardListOrderChangedDomainEvent : IDomainEvent
    {
        public Guid ListId { get; init; }
        public decimal Order { get; init; }
    }
}
