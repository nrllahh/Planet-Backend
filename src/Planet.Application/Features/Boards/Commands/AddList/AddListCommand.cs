using Planet.Application.Common;

namespace Planet.Application.Features.Boards.Commands.AddList
{
    public sealed class AddListCommand : CommandBase<AddListResponse>
    {
        public Guid BoardId { get; init; }
        public string Title { get; init; }
        public decimal Order { get; init; }
    }
}
