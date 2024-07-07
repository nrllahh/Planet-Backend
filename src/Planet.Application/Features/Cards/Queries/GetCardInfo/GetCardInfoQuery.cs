using Planet.Application.Common;

namespace Planet.Application.Features.Cards.Queries.GetCardInfo
{
    public sealed class GetCardInfoQuery : QueryBase<GetCardInfoResponse>
    {
        public Guid CardId { get; init; }
    }
}
