using Planet.Application.Common;

namespace Planet.Application.Features.Boards.Commands.EditBoard
{
    public sealed class EditBoardCommand : CommandBase<EditBoardResponse>
    {
        public Guid BoardId { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
    }
}
