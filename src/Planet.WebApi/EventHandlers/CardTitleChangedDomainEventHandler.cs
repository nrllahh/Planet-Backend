using MediatR;
using Microsoft.AspNetCore.SignalR;
using Planet.Application.Services.Repositories;
using Planet.Domain.Cards.DomainEvents;
using Planet.WebApi.Hubs;

namespace Planet.WebApi.EventHandlers
{
    public class CardTitleChangedDomainEventHandler : INotificationHandler<CardTitleChangedDomainEvent>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IHubContext<BoardHub, IBoardClient> _hubContext;

        public CardTitleChangedDomainEventHandler(IBoardRepository boardRepository, IHubContext<BoardHub, IBoardClient> hubContext)
        {
            _boardRepository = boardRepository;
            _hubContext = hubContext;
        }

        public async Task Handle(CardTitleChangedDomainEvent notification, CancellationToken cancellationToken)
        {
            var boardId = await _boardRepository.GetBoardIdByCardId(notification.CardId);
            await _hubContext.Clients.Group($"BOARD[{boardId}]").ReceiveCardTitleChangedEvent(notification);
        }
    }
}
