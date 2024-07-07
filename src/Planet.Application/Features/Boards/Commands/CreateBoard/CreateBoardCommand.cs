using Planet.Application.Common;
using Planet.Domain.Boards;

namespace Planet.Application.Features.Boards.Commands.CreateBoard
{
    public sealed class CreateBoardCommand : CommandBase<CreateBoardResponse>
    {
        public string Title { get; init; }
        public string Description { get; init; }
        public BoardModules Modules { get; init; } = BoardModules.Default;
    }
}
