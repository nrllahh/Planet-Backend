using Planet.Domain.SharedKernel;
using System.Net;

namespace Planet.Domain.Boards
{
    public sealed class Board : Entity, IAggregateRoot
    {
        public BoardTitle Title { get; private set; }
        public BoardDescription Description { get; private set; }
        public BoardModules Modules { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public bool IsActive { get; private set; }
        public Guid OwnerId { get; private set; }
        public IReadOnlyCollection<BoardMember> Members => _members?.ToList();
        public IReadOnlyCollection<BoardList> Lists => _lists?.ToList();
        public IReadOnlyCollection<BoardLabel> Labels => _labels?.ToList();

        private HashSet<BoardMember> _members = new();
        private HashSet<BoardLabel> _labels = new();
        private HashSet<BoardList> _lists = new();

        private Board() : base(Guid.Empty)
        {
        }

        private Board(Guid id,
            BoardTitle title,
            BoardDescription description,
            BoardModules modules,
            DateTime createdDate,
            bool isActive,
            Guid ownerId) : base(id)
        {
            Title = title;
            Description = description;
            Modules = modules;
            CreatedDate = createdDate;
            IsActive = isActive;
            OwnerId = ownerId;
        }

        private Board(Guid id,
            BoardTitle title,
            BoardDescription description,
            BoardModules modules,
            DateTime createdDate,
            Guid ownerId) : base(id)
        {
            Title = title;
            Description = description;
            Modules = modules;
            CreatedDate = createdDate;
            IsActive = true;
            OwnerId = ownerId;
        }

        public static Board Create(Guid id,
            BoardTitle title,
            BoardDescription description,
            BoardModules modules,
            DateTime createdDate,
            bool isActive,
            Guid ownerId)
        {
            return new Board(id, title, description, modules, createdDate, isActive, ownerId);
        }

        public static Board Create(Guid id,
            BoardTitle title,
            BoardDescription description,
            BoardModules modules,
            DateTime createdDate,
            Guid ownerId)
        {
            var board = new Board(id, title, description, modules, createdDate, ownerId);
            var boardMember = BoardMember.Create(ownerId, board.Id, BoardPermissions.All, createdDate, true);
            board.AddMember(boardMember);

            return board;
        }

        public void ChangeBoardTitle(BoardTitle title)
        {
            Title = title;
        }
        public void ChangeBoardDescription(BoardDescription description)
        {
            Description = description;
        }

        public void AddMember(BoardMember member)
        {
            _members.Add(member);
        }

        public void AddList(BoardList list)
        {
            _lists.Add(list);
        }

        public void RemoveList(BoardList boardList)
        {
            _lists.Remove(boardList);
        }

        public void RemoveMember(BoardMember member)
        {
            _members.Remove(member);
        }

        public void AddLabel(BoardLabel label)
        {
            _labels.Add(label);
        }

        public void EditList(Guid listId, BoardTitle title, decimal order)
        {
            var list = _lists.FirstOrDefault(x => x.Id == listId);
            list?.Edit(title, order);
        }
    }
}
