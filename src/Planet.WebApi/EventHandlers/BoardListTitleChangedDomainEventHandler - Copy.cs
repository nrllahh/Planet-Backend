using MediatR;
using Microsoft.AspNetCore.SignalR;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards.DomainEvents;
using Planet.WebApi.Hubs;

namespace Planet.WebApi.EventHandlers
{
    public class BoardListOrderChangedDomainEventHandler : INotificationHandler<BoardListOrderChangedDomainEvent>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IHubContext<BoardHub, IBoardClient> _hubContext;

        public BoardListOrderChangedDomainEventHandler(IBoardRepository boardRepository, IHubContext<BoardHub, IBoardClient> hubContext)
        {
            _boardRepository = boardRepository;
            _hubContext = hubContext;
        }

        public async Task Handle(BoardListOrderChangedDomainEvent notification, CancellationToken cancellationToken)
        {
            var boardId = await _boardRepository.GetBoardIdByBoardListId(notification.ListId);
            await _hubContext.Clients.Group($"BOARD[{boardId}]").ReceiveBoardListOrderChangedEvent(notification);
        }
    }
}
