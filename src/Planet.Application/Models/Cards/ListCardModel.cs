namespace Planet.Application.Models.Cards
{
    public class ListCardModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Order { get; set; }
        public Guid ListId { get; set; }
        public Guid? UserId { get; set; }
        public string FullName { get; set; }
        public List<ListCardLabel> Labels { get; set; } = new();
    }

    public class ListCardLabel
    {
        public Guid CardId { get; set; }
        public string Title { get; set; }
        public string ColorCode { get; set; }
        public Guid BoardLabelId { get; set; }
    }
}
