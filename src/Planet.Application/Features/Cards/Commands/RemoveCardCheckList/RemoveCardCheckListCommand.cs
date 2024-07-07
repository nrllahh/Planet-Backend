using Planet.Application.Common;

namespace Planet.Application.Features.Cards.Commands.RemoveCardCheckList
{
    public class RemoveCardCheckListCommand : CommandBase<RemoveCardCheckListResponse>
    {
        public Guid CardId { get; init; }
        public Guid CheckListId { get; init; }
    }
}
