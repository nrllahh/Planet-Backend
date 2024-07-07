using Dapper;
using Microsoft.EntityFrameworkCore;
using Planet.Application.Models.Users;
using Planet.Application.Services.Repositories;
using Planet.Application.Services.SqlConnection;
using Planet.Domain.Users;
using Planet.Persistence.Contexts;

namespace Planet.Persistence.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly PlanetContext _context;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public UserRepository(PlanetContext context, ISqlConnectionFactory sqlConnectionFactory)
        {
            _context = context;
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public Task<User> FindAsync(Guid id)
        {
            return _context.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public Task<User> FindByEmailAsync(string email)
        {
            return _context.Users.SingleOrDefaultAsync(u => u.Email.Value == email);
        }

        public async Task<UserStatisticsModel> GetUserStatistics(Guid userId)
        {
            string sql = @"
            SELECT
                (SELECT COUNT(*) FROM BoardMembers WHERE UserId = @UserId) AS BoardMemberCount,
                (SELECT COUNT(*) FROM CardComments WHERE UserId = @UserId) AS CardCommentCount,
                (SELECT COUNT(*) FROM Cards WHERE OwnerId = @UserId) AS CardOwnerCount,
                (SELECT COUNT(*) FROM Cards WHERE AssignedToId = @UserId) AS CardAssignedCount;
            ";

            using var connection = _sqlConnectionFactory.GetConnection();

            return await connection.QueryFirstOrDefaultAsync<UserStatisticsModel>(sql, new {UserId = userId});
        }
    }
}