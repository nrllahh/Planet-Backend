using Planet.Application.Common;

namespace Planet.Application.Features.Cards.Commands.CreateCard
{
    public class CreateCardCommand : CommandBase<CreateCardResponse>
    {
        public string Title { get; init; }
        public Guid ListId { get; init; }
        public double Order { get; init; }
    }
}
