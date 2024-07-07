using Planet.Application.Common;

namespace Planet.Application.Features.Cards.Commands.RemoveCardCheckListItem
{
    public sealed class RemoveCardCheckListItemCommand : CommandBase<RemoveCardCheckListItemResponse>
    {
        public Guid CardId { get; init; }
        public Guid CheckListId { get; init; }
        public Guid CheckListItemId { get; init; }
    }
}
