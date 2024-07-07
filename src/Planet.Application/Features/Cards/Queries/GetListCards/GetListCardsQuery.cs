using Planet.Application.Common;

namespace Planet.Application.Features.Cards.Queries.GetListCards
{
    public sealed class GetListCardsQuery : PaginationQuery<GetListCardsResponse>
    {

        public Guid ListId { get; init; }
    }
}
