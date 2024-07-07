using Planet.Application.Common;

namespace Planet.Application.Features.Boards.Commands.AddLabel
{
    public sealed class AddLabelCommand : CommandBase<AddLabelResponse>
    {
        public Guid BoardId { get; init; }
        public string ColorCode { get; init; }
        public string Title { get; init; }
    }
}
