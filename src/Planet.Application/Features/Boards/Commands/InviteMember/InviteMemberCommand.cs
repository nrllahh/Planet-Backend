using Planet.Application.Common;

namespace Planet.Application.Features.Boards.Commands.InviteMember
{
    public sealed class InviteMemberCommand : CommandBase<InviteMemberResponse>
    {
        public Guid BoardId { get; init; }
    }
}
