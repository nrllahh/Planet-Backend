using Planet.Application.Common;

namespace Planet.Application.Features.Cards.Commands.EditCardCheckListTitle
{
    public class EditCardCheckListTitleCommand : CommandBase<EditCardCheckListTitleResponse>
    {
        public Guid CardId { get; init; }
        public Guid CheckListId { get; init; }
        public string NewTitle { get; init; }
    }
}
