using Planet.Application.Common;

namespace Planet.Application.Features.Cards.Commands.EditDate
{
    public class EditDateCommand : CommandBase<EditDateResponse>
    {
        public Guid CardId { get; init; }
        public DateTime? StartDate { get; init; }
        public DateTime? EndDate { get; init; }
    }
}
