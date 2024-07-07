using Planet.Application.Common;

namespace Planet.Application.Features.Cards.Commands.AddLabel
{
    public class AddLabelCommand : CommandBase<AddLabelResponse>
    {
        public Guid CardId { get; init; }
        public Guid BoardLabelId { get; init; }
    }
}
