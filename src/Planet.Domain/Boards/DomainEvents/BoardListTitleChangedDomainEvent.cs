using Planet.Domain.SharedKernel;

namespace Planet.Domain.Boards.DomainEvents
{
    public sealed class BoardListTitleChangedDomainEvent : IDomainEvent
    {
        public Guid ListId { get; init; }
        public string Title { get; set; }

    }
}
