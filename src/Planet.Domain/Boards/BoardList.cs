using Planet.Domain.Boards.DomainEvents;
using Planet.Domain.SharedKernel;
using System.Xml.Schema;

namespace Planet.Domain.Boards
{
    public sealed class BoardList : Entity, IAggregateRoot
    {
        public Guid BoardId { get; private set; }
        public BoardTitle Title { get; private set; }
        public decimal Order { get; private set; }
        private BoardList() : base(Guid.Empty) { }

        private BoardList(
            Guid id,
            Guid boardId,
            BoardTitle title,
            decimal order) : base(id)
        {
            BoardId = boardId;
            Title = title;
            Order = order;
        }
        public static BoardList Create(
            Guid id,
            Guid boardId,
            BoardTitle title,
            decimal order)
        {
            return new BoardList(id, boardId, title, order);
        }

        public void Edit(BoardTitle title, decimal order)
        {
            if (title != Title)
            {
                RaiseDomainEvent(new BoardListTitleChangedDomainEvent
                {
                    ListId = Id,
                    Title = title.Value
                });
            }

            if (order != Order)
            {
                RaiseDomainEvent(new BoardListOrderChangedDomainEvent
                {
                    ListId = Id,
                    Order = order
                });
            }

            Title = title;
            Order = order;
        }
    }
}
