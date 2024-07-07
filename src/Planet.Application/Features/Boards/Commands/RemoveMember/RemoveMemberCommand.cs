using Planet.Application.Common;

namespace Planet.Application.Features.Boards.Commands.RemoveMember
{
    public sealed class RemoveMemberCommand : CommandBase<RemoveMemberResponse>
    {
        public Guid BoardId { get; init; }
        public Guid UserId { get; init; }
    }

}
