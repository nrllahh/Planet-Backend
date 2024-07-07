using MediatR;
using Microsoft.AspNetCore.SignalR;
using Planet.Application.Services.Repositories;
using Planet.Domain.Cards.DomainEvents;
using Planet.WebApi.Hubs;

namespace Planet.WebApi.EventHandlers
{
    public class CardMovedDomainEventHandler : INotificationHandler<CardMovedDomainEvent>
    {
        private readonly IHubContext<BoardHub, IBoardClient> _hubContext;
        private readonly IBoardRepository _boardRepository;

        public CardMovedDomainEventHandler(IHubContext<BoardHub, IBoardClient> hubContext, IBoardRepository boardRepository)
        {
            _hubContext = hubContext;
            _boardRepository = boardRepository;
        }

        public async Task Handle(CardMovedDomainEvent notification, CancellationToken cancellationToken)
        {
            var boardId = await _boardRepository.GetBoardIdByBoardListId(notification.OldListId);
            await _hubContext.Clients.Group($"BOARD[{boardId}]").ReceiveCardMovedEvent(notification);
        }
    }
}
