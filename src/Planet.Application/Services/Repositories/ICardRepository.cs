using Planet.Application.Common;
using Planet.Application.Features.Cards.Queries.GetListCards;
using Planet.Application.Models.Cards;
using Planet.Domain.Cards;

namespace Planet.Application.Services.Repositories
{
    public interface ICardRepository : ICardDomainRepository
    {
        Task<CardModel> GetCardInfo(Guid cardId);
        Task<Pagination<ListCardModel>> GetListCardsAsync(GetListCardsQuery query);
    }
}
