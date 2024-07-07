using Planet.Application.Common;

namespace Planet.Application.Features.Cards.Commands.AddCardCheckList
{
    public class AddCardCheckListCommand : CommandBase<AddCardCheckListResponse>
    {
        public Guid CardId { get; init; }
        public string Title { get; init; }

    }
}
