using Planet.Domain.Users;

namespace Planet.Application.Models.Users
{
    public sealed class UserStatisticsModel
    {
        public int BoardMemberCount { get; set; }
        public int CardCommentCount { get; set; }
        public int CardOwnerCount { get; set; }
        public int CardAssignedCount { get;  set; }
    }
}
