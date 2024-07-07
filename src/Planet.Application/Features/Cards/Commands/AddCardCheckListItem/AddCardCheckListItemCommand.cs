using Planet.Application.Common;

namespace Planet.Application.Features.Cards.Commands.AddCardCheckListItem
{
    public sealed class AddCardCheckListItemCommand : CommandBase<AddCardCheckListItemResponse>
    {
        public Guid CardId { get; init; }
        public Guid CheckListId { get; init; }
        public string Content { get; init; }
    }
}
