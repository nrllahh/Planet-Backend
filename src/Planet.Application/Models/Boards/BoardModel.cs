namespace Planet.Application.Models.Boards
{
    public sealed class BoardModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<BoardMemberModel> Members { get; set; } = new();
        public List<BoardListModel> Lists { get; set; } = new();
        public List<BoardLabelModel> Labels { get; set; } = new();
    }

    public sealed class BoardMemberModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public sealed class BoardListModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Order { get; set; }
    }

    public sealed class BoardLabelModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ColorCode { get; set; }
    }
}
