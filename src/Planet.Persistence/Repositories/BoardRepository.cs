using Dapper;
using Microsoft.EntityFrameworkCore;
using Planet.Application.Common;
using Planet.Application.Features.Boards.Queries.GetUserBoards;
using Planet.Application.Models.Boards;
using Planet.Application.Services.Repositories;
using Planet.Application.Services.SqlConnection;
using Planet.Domain.Boards;
using Planet.Persistence.Contexts;

namespace Planet.Persistence.Repositories
{
    public sealed class BoardRepository : IBoardRepository
    {
        private readonly PlanetContext _context;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public BoardRepository(PlanetContext context, ISqlConnectionFactory sqlConnectionFactory)
        {
            _context = context;
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public async Task CreateAsync(Board board)
        {
            await _context.Boards.AddAsync(board);
        }

        public Task<Board> FindAsync(Guid id)
        {
            return _context.Boards.Include(b => b.Lists)
                .Include(b => b.Labels)
                .SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<BoardModel> GetBoardAsync(Guid boardId)
        {
            string sql = @"
            SELECT b.Id, b.Title, b.Description FROM Boards b
            WHERE b.Id = @BoardId

            SELECT u.Id, u.FirstName, u.LastName, u.Email FROM BoardMembers bm
            INNER JOIN Users u ON u.Id = bm.UserId
            WHERE bm.BoardId = @BoardId
            
            SELECT bla.Id, bla.Title, bla.ColorCode FROM BoardLabels bla
            WHERE bla.BoardId = @BoardId
            
            SELECT bli.Id, bli.Title, bli.[Order] FROM BoardLists bli
            WHERE bli.BoardId = @BoardId
            ORDER BY bli.[Order] ASC
            ";

            using var connection = _sqlConnectionFactory.GetConnection();

            var gridReader = await connection.QueryMultipleAsync(sql, new { BoardId = boardId });
            var boardModel = await gridReader.ReadFirstOrDefaultAsync<BoardModel>();
            boardModel.Members = (await gridReader.ReadAsync<BoardMemberModel>()).ToList();
            boardModel.Labels = (await gridReader.ReadAsync<BoardLabelModel>()).ToList();
            boardModel.Lists = (await gridReader.ReadAsync<BoardListModel>()).ToList();

            return boardModel;
        }

        public async Task<Guid?> GetBoardIdByBoardListId(Guid listId)
        {
            string sql = @"
            SELECT b.Id FROM BoardLists bl
            INNER JOIN Boards b ON b.Id = bl.BoardId
            WHERE bl.Id = @ListId
            ";

            using var connection = _sqlConnectionFactory.GetConnection();
            return await connection.QueryFirstOrDefaultAsync<Guid?>(sql, new { ListId = listId });
        }

        public async Task<Guid?> GetBoardIdByCardId(Guid cardId)
        {
            string sql = @"
            SELECT bl.BoardId FROM Cards c
            INNER JOIN BoardLists bl ON bl.Id = c.ListId
            WHERE c.Id = @CardId
            ";

            using var connection = _sqlConnectionFactory.GetConnection();
            return await connection.QueryFirstOrDefaultAsync<Guid?>(sql, new { CardId = cardId });
        }

        public async Task<Pagination<UserBoardModel>> GetUserBoardsAsync(GetUserBoardsQuery query, Guid userId)
        {
            var parameters = new DynamicParameters();
            parameters.AddDynamicParams(query);
            parameters.Add("@UserId", userId);

            string sql = @"
            SELECT COUNT(*) FROM BoardMembers bm
            INNER JOIN Boards b ON b.Id = bm.BoardId
            WHERE bm.UserId = @UserId AND b.IsActive = 1 AND bm.IsActive = 1

            SELECT b.Id, b.Title FROM BoardMembers bm
            INNER JOIN Boards b ON b.Id = bm.BoardId
            WHERE bm.UserId = @UserId AND b.IsActive = 1 AND bm.IsActive = 1
            ORDER BY b.Title ASC
            OFFSET @PageSize * (@CurrentPage - 1) ROWS
            FETCH NEXT @PageSize ROWS ONLY
            ";

            using var connection = _sqlConnectionFactory.GetConnection();
            var gridReader = await connection.QueryMultipleAsync(sql, parameters);

            int recordCount = await gridReader.ReadFirstOrDefaultAsync<int>();
            var items = await gridReader.ReadAsync<UserBoardModel>();

            return new Pagination<UserBoardModel>
            {
                CurrentPage = query.CurrentPage,
                PageSize = query.PageSize,
                RecordCount = recordCount,
                Items = items.ToList()
            };

        }

        public async Task<bool> HasBoardLabelAsync(Guid boardId, Guid boardLabelId)
        {
            string sql = @"
            SELECT COUNT(*) FROM BoardLabels
            WHERE Id = @BoardLabelId AND BoardId = @BoardId
            ";

            using var connection = _sqlConnectionFactory.GetConnection();
            return (await connection.QueryFirstOrDefaultAsync<int>(sql, new { BoardLabelId = boardLabelId, BoardId = boardId })) > 0;
        }

        public async Task<bool> HasBoardListAnyCard(Guid listId)
        {
            string sql = @"
            SELECT COUNT(*) FROM Cards c
            WHERE c.ListId = @ListId
            ";

            using var connection = _sqlConnectionFactory.GetConnection();

            return (await connection.QueryFirstOrDefaultAsync<int>(sql, new { ListId = listId })) > 0;
        }

        public async Task<bool> HasPermissionAsync(BoardPermissions permission, Guid boardId, Guid userId)
        {
            string sql = @"
            SELECT TOP(1) Permissions FROM BoardMembers bm
            WHERE bm.IsActive = 1 AND bm.BoardId = @BoardId AND bm.UserId = @UserId
            ";

            using var connection = _sqlConnectionFactory.GetConnection();
            var permissions = await connection.QueryFirstOrDefaultAsync<BoardPermissions?>(sql, new { UserId = userId, BoardId = boardId });

            return permissions?.HasFlag(permissions) ?? false;
        }

        public async Task<bool> HasPermissionForListAsync(BoardPermissions permission, Guid listId, Guid userId)
        {
            string sql = @"
            SELECT TOP(1) Permissions FROM BoardMembers bm
            INNER JOIN BoardLists bl ON bl.BoardId = bm.BoardId
            WHERE bl.Id = @ListId AND bm.UserId = @UserId
            ";

            using var connection = _sqlConnectionFactory.GetConnection();
            var permissions = await connection.QueryFirstOrDefaultAsync<BoardPermissions?>(sql, new { UserId = userId, ListId = listId });
            return permissions?.HasFlag(permissions) ?? false;
        }
    }
}
