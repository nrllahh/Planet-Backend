using Microsoft.AspNetCore.SignalR;
using Planet.Domain.Boards.DomainEvents;
using Planet.Domain.Cards.DomainEvents;

namespace Planet.WebApi.Hubs
{
    public class BoardHub : Hub<IBoardClient>
    {
        public async Task JoinBoardGroup(string boardId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"BOARD[{boardId}]");
        }

        public async Task LeaveBoardGroup(string boardId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"BOARD[{boardId}]");
        }
    }

    public interface IBoardClient
    {
        Task ReceiveCardMovedEvent(CardMovedDomainEvent @event);
        Task ReceiveCardTitleChangedEvent(CardTitleChangedDomainEvent @event);
        Task ReceiveBoardListTitleChangedEvent(BoardListTitleChangedDomainEvent @event);
        Task ReceiveBoardListOrderChangedEvent(BoardListOrderChangedDomainEvent @event);
    }
}
