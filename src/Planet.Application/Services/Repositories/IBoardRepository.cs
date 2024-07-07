using Planet.Application.Common;
using Planet.Application.Features.Boards.Queries.GetUserBoards;
using Planet.Application.Models.Boards;
using Planet.Domain.Boards;

namespace Planet.Application.Services.Repositories
{
    public interface IBoardRepository : IBoardDomainRepository
    {
        Task<Pagination<UserBoardModel>> GetUserBoardsAsync(GetUserBoardsQuery query, Guid userId);
        Task<bool> HasPermissionAsync(BoardPermissions permission, Guid boardId, Guid userId);
        Task<bool> HasPermissionForListAsync(BoardPermissions permission, Guid listId, Guid userId);
        Task<BoardModel> GetBoardAsync(Guid boardId);
        Task<bool> HasBoardListAnyCard(Guid listId);
        Task<bool> HasBoardLabelAsync(Guid boardId, Guid boardLabelId);
        Task<Guid?> GetBoardIdByBoardListId(Guid listId);
        Task<Guid?> GetBoardIdByCardId(Guid cardId);
    }
}
