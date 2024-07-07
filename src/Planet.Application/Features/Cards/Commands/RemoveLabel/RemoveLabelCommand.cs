using Planet.Application.Common;

namespace Planet.Application.Features.Cards.Commands.RemoveLabel
{
    public class RemoveLabelCommand : CommandBase<RemoveLabelResponse>
    {
        public Guid CardId { get; init; }
        public Guid BoardLabelId { get; init; }
    }
}
