using Planet.Application.Common;

namespace Planet.Application.Features.Cards.Commands.EditCardCheckListItem
{
    public sealed class EditCardCheckListItemCommand : CommandBase<EditCardCheckListItemResponse>
    {
        public Guid CardId { get; init; }
        public Guid CheckListId { get; init; }
        public Guid CheckListItemId { get; init; }
        public bool IsChecked { get; init; }
        public string Content { get; init; }
    }
}
