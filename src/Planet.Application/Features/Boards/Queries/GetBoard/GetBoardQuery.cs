using Planet.Application.Common;

namespace Planet.Application.Features.Boards.Queries.GetBoard
{
    public sealed class GetBoardQuery : QueryBase<GetBoardResponse>
    {
        public Guid BoardId { get; init; }
    }
}
