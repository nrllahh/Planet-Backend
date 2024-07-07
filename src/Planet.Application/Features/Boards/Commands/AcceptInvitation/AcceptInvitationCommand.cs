using Planet.Application.Common;

namespace Planet.Application.Features.Boards.Commands.AcceptInvitation
{
    public sealed class AcceptInvitationCommand : CommandBase<AcceptInvitationResponse>
    {
        public string InvitationKey { get; init; }
    }
}
