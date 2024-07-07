namespace Planet.Domain.Boards
{
    public record BoardMember
    {
        public Guid UserId { get; init; }
        public Guid BoardId { get; init; }
        public BoardPermissions Permissions { get; init; }
        public DateTime JoinedDate { get; init; }
        public bool IsActive { get; init; }

        private BoardMember() { }

        private BoardMember(
            Guid userId,
            Guid boardId,
            BoardPermissions permissions,
            DateTime joinedDate,
            bool isActive)
        {
            UserId = userId;
            BoardId = boardId;
            Permissions = permissions;
            JoinedDate = joinedDate;
            IsActive = isActive;
        }

        public static BoardMember Create(
            Guid userId,
            Guid boardId,
            BoardPermissions permissions,
            DateTime joinedDate,
            bool isActive)
        {
            return new BoardMember(userId, boardId, permissions, joinedDate, isActive);
        }
    }
}
