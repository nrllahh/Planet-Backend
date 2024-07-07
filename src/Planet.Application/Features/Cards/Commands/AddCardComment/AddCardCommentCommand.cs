using Planet.Application.Common;

namespace Planet.Application.Features.Cards.Commands.AddCardComment
{
    public class AddCardCommentCommand : CommandBase<AddCardCommentResponse>
    {
        public Guid CardId { get; init; }
        public string Comment { get; init; }
    }
}
