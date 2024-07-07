using Planet.Domain.SharedKernel;

namespace Planet.Domain.Cards
{
    public sealed class CardCheckListItem : Entity
    {
        public CardCheckListItemContent Content { get; private set; }
        public bool IsChecked { get; private set; }
        public Guid CheckListId { get; private set; }
        private CardCheckListItem() : base(Guid.Empty) { }
        private CardCheckListItem(
            Guid id,
            CardCheckListItemContent content,
            bool isChecked,
            Guid checkListId) : base(id)
        {
            Content = content;
            IsChecked = isChecked;
            CheckListId = checkListId;
        }
        public static CardCheckListItem Create(
            Guid id,
            CardCheckListItemContent content,
            bool isChecked,
            Guid checkListId)
        {
            return new CardCheckListItem(id, content, isChecked, checkListId);
        }

        public void Edit(string content, bool isChecked)
        {
            Content = CardCheckListItemContent.Create(content);
            IsChecked = isChecked;
        }

    }
}
