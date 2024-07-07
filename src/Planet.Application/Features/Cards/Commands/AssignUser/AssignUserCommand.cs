using Planet.Application.Common;

namespace Planet.Application.Features.Cards.Commands.AssignUser
{
    public class AssignUserCommand : CommandBase<AssignUserResponse>
    {
        public Guid CardId { get; init; }
        public Guid? UserId { get; init; }
    }

}
