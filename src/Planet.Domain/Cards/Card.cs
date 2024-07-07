using Planet.Domain.Cards.DomainEvents;
using Planet.Domain.SharedKernel;

namespace Planet.Domain.Cards
{
    public sealed class Card : Entity, IAggregateRoot
    {
        public CardTitle Title { get; private set; }
        public CardDates Dates { get; private set; }
        public CardDescription Description { get; private set; }
        public Guid ListId { get; private set; }
        public Guid OwnerId { get; private set; }
        public Guid? AssignedToId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public double Order { get; private set; }
        public bool IsDeleted { get; private set; }

        public IReadOnlyCollection<CardCheckList> CheckLists => _checkLists?.ToList();
        public IReadOnlyCollection<CardLabel> Labels => _labels?.ToList();
        public IReadOnlyCollection<CardComment> Comments => _comments?.ToList();

        private HashSet<CardCheckList> _checkLists = new HashSet<CardCheckList>();
        private HashSet<CardLabel> _labels = new HashSet<CardLabel>();
        private HashSet<CardComment> _comments = new HashSet<CardComment>();

        private Card() : base(Guid.Empty) { }

        private Card(
           Guid id,
           CardTitle title,
           CardDescription description,
           Guid ownerId,
           Guid listId,
           DateTime createdDate,
           Guid? assignedToId,
           int order,
           bool isDeleted) : base(id)

        {
            Title = title;
            Description = description;
            OwnerId = ownerId;
            ListId = listId;
            CreatedDate = createdDate;
            AssignedToId = assignedToId;
            Order = order;
            IsDeleted = isDeleted;
        }

        private Card(Guid id, Guid listId, CardTitle title, Guid ownerId, DateTime createdDate, double order) : base(id)
        {
            Title = title;
            OwnerId = ownerId;
            ListId = listId;
            CreatedDate = createdDate;
            Description = CardDescription.Create(string.Empty);
            Order = order;
        }

        public static Card Create(Guid id, Guid listId, CardTitle title, Guid ownerId, DateTime createdDate, double order)
        {
            return new Card(id, listId, title, ownerId, createdDate, order);
        }

        public static Card Create(
            Guid id,
            CardTitle title,
            CardDescription description,
            Guid ownerId,
            Guid listId,
            DateTime createdDate,
            Guid? assignedToId,
            int order,
            bool isDeleted)
        {
            return new Card(id, title, description, ownerId, listId, createdDate, assignedToId, order, isDeleted);
        }

        public void ChangeCardDescription(CardDescription description)
        {
            Description = description;
        }
        public void ChangeCardTitle(CardTitle title)
        {
            Title = title;

            RaiseDomainEvent(new CardTitleChangedDomainEvent
            {
                CardId = Id,
                Title = title.Value
            });
        }
        public void AddLabel(CardLabel label)
        {
            _labels.Add(label);
        }

        public void RemoveLabel(CardLabel label)
        {
            _labels.Remove(label);
        }

        public void ChangeDate(CardDates date)
        {
            Dates = date;
        }

        public void AddComment(CardComment cardComment)
        {
            _comments.Add(cardComment);
        }

        public void AddCheckList(CardCheckList cardCheckList)
        {
            _checkLists.Add(cardCheckList);
        }

        public void AssignUser(Guid? userId)
        {
            AssignedToId = userId;
        }

        public void MoveToList(Guid newListId, double newOrder)
        {
            var cardMovedDomainEvent = new CardMovedDomainEvent
            {
                CardId = Id,
                NewListId = newListId,
                NewOrder = newOrder,
                OldOrder = Order,
                OldListId = ListId
            };

            ListId = newListId;
            Order = newOrder;

            RaiseDomainEvent(cardMovedDomainEvent);
        }

        public void RemoveCheckList(Guid checkListId)
        {
            var checkList = _checkLists.FirstOrDefault(c => c.Id == checkListId);
            _checkLists.Remove(checkList);
        }

        public void EditCheckListTitle(Guid checkListId, CardTitle title)
        {
            var checkList = _checkLists.FirstOrDefault(c => c.Id == checkListId);
            checkList?.ChangeTitle(title);
        }

        public void EditCardCheckListItem(Guid checkListId, Guid cardCheckListItemId, string content, bool isChecked)
        {
            var checkList = _checkLists.FirstOrDefault(cl => cl.Id == checkListId);
            checkList?.EditItem(cardCheckListItemId, content, isChecked);
        }

        public void AddCardCheckListItem(CardCheckListItem item)
        {
            var checkList = _checkLists.FirstOrDefault(cl => cl.Id == item.CheckListId);
            checkList?.AddItem(item);
        }

        public void RemoveCardCheckListItem(Guid checkListId, Guid cardCheckListItemId)
        {
            var checkList = _checkLists.FirstOrDefault(cl => cl.Id == checkListId);
            checkList?.RemoveItem(cardCheckListItemId);
        }

        public void Remove()
        {
           IsDeleted = true;
        }
    }
}
