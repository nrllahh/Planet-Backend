namespace Planet.Application.Models.Cards
{
    public sealed class CardModel
    {
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public Guid ListId { get; set; }
        public DateTime CreatedDate { get; set; }
        public double Order { get; private set; }
        public bool IsDeleted { get; set; }
        public List<CardCheckListModel> CheckLists { get; set; } = new();
        public List<CardLabelModel> Labels { get; set; } = new();
        public List<CardCommentModel> Comments { get; set; } = new();
        public List<CardUserModel> Users { get; set; } = new();
    }
    public sealed class CardCheckListModel
    {
        public Guid Id { get; set; }
        public Guid CardId { get; set; }
        public string Title { get; set; }
        public List<CardCheckListItemModel> Items { get; set; } = new();
    }

    public sealed class CardCheckListQueryModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid? ItemId { get; set; }
        public string Content { get; set; }
        public bool IsChecked { get; set; }
    }

    public sealed class CardCheckListItemModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public bool IsChecked { get; set; }
    }
    public sealed class CardLabelModel
    {
        public string ColorCode { get; set; }
        public string Title { get; set; }
        public Guid CardId { get; set; }
        public Guid BoardLabelId { get; set; }
    }
    public sealed class CardCommentModel
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Content { get; set; }
    }

    public sealed class CardUserModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public CardUserType Type { get; set; }
    }

    public enum CardUserType
    {
        None = 0,
        Owner = 1,
        Assignee = 2,
    }
}
