using Planet.Application.Common;

namespace Planet.Application.Features.Cards.Commands.EditCardDescription
{
    public class EditCardDescriptionCommand : CommandBase<EditCardDescriptionResponse>
    {
        public Guid CardId { get; init; }
        public string Description { get; init; }
    }
}