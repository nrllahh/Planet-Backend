using Planet.Domain.SharedKernel;
namespace Planet.Domain.Boards
{
    public sealed class BoardLabel : Entity
    {
        public Guid BoardId { get; private set; }
        public BoardLabelColor Color { get; private set; }
        public BoardTitle Title { get; private set; }
        public bool IsActive { get; private set; }
        private BoardLabel() : base(Guid.Empty) { }
        private BoardLabel(
            Guid id,
            Guid boardId,
            BoardLabelColor color,
            BoardTitle title,
            bool isActive) : base(id)
        {
            BoardId = boardId;
            Color = color;
            Title = title;
            IsActive = isActive;
        }
        public static BoardLabel Create(Guid id,
            Guid boardId,
            BoardLabelColor color,
            BoardTitle title,
            bool isActive)
        {
            return new BoardLabel(id, boardId, color, title, isActive);
        }
        public static BoardLabel Create(Guid id,
            Guid boardId,
            BoardLabelColor color,
            BoardTitle title)
        {
            return new BoardLabel(id, boardId, color, title, true);
        }
    }
}
