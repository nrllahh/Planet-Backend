using Planet.Application.Common;

namespace Planet.Application.Features.Cards.Commands.MoveTo
{
    public class MoveCardCommand : CommandBase<MoveCardResponse>
    {
        public Guid CardId { get; init; }
        public Guid NewListId { get; init; }
        public double NewOrder { get; init; }
    }
}
