using Planet.Application.Common;

namespace Planet.Application.Features.Boards.Commands.RemoveList
{
    public sealed class RemoveListCommand : CommandBase<RemoveListResponse>
    {
        public Guid BoardId { get; init; }
        public Guid ListId { get; init; }
    }
}
