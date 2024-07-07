using Dapper;
using Microsoft.EntityFrameworkCore;
using Planet.Application.Common;
using Planet.Application.Features.Cards.Queries.GetListCards;
using Planet.Application.Models.Cards;
using Planet.Application.Services.Repositories;
using Planet.Application.Services.SqlConnection;
using Planet.Domain.Cards;
using Planet.Persistence.Contexts;

namespace Planet.Persistence.Repositories
{
    public sealed class CardRepository : ICardRepository
    {
        private readonly PlanetContext _context;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public CardRepository(PlanetContext context, ISqlConnectionFactory sqlConnectionFactory)
        {
            _context = context;
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task CreateAsync(Card entity)
        {
            await _context.Cards.AddAsync(entity);
        }

        public Task<Card> FindAsync(Guid id)
        {
            return _context.Cards.
                Include(c => c.CheckLists).ThenInclude(cl => cl.Items).AsSplitQuery().
                Include(c => c.Labels).
                Include(c => c.Comments).
                SingleOrDefaultAsync(c => c.Id == id);
        }


        public async Task<Pagination<ListCardModel>> GetListCardsAsync(GetListCardsQuery query)
        {
            var parameters = new DynamicParameters();
            parameters.AddDynamicParams(query);

            string sql = @"
            SELECT COUNT(*)
            FROM Cards c
            WHERE c.ListId = @ListId

            SELECT c.Id, c.ListId, c.Title, c.[Order], u.Id UserId, u.FirstName + ' ' + u.LastName FullName
            FROM Cards c LEFT JOIN Users u ON u.Id = c.AssignedToId
            WHERE c.ListId = @ListId
            ORDER BY c.[Order] ASC
            OFFSET @PageSize * (@CurrentPage - 1) ROWS
            FETCH NEXT @PageSize ROWS ONLY

            SELECT bl.Title, bl.ColorCode, cl.CardId, bl.Id BoardLabelId FROM CardLabels cl
            INNER JOIN BoardLabels bl ON bl.Id = cl.BoardLabelId
            WHERE cl.CardId IN(
	            SELECT c.Id
	            FROM Cards c LEFT JOIN Users u ON u.Id = c.AssignedToId
	            WHERE c.ListId = @ListId
	            ORDER BY c.[Order] ASC
	            OFFSET @PageSize * (@CurrentPage - 1) ROWS
	            FETCH NEXT @PageSize ROWS ONLY
            )";


            using var connection = _sqlConnectionFactory.GetConnection();
            var gridReader = await connection.QueryMultipleAsync(sql, parameters);

            int recordCount = await gridReader.ReadFirstOrDefaultAsync<int>();
            var items = await gridReader.ReadAsync<ListCardModel>();
            var labels = await gridReader.ReadAsync<ListCardLabel>();

            foreach (var item in items)
            {
                item.Labels = labels.Where(l => item.Id == l.CardId).ToList();
            }

            return new Pagination<ListCardModel>
            {
                CurrentPage = query.CurrentPage,
                PageSize = query.PageSize,
                RecordCount = recordCount,
                Items = items.ToList()
            };

        }

        public Task<Card> FindListIdByCardAsync(Guid id)
        {
            return _context.Cards.SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task<CardModel> GetCardInfo(Guid cardId)
        {
            string sql = @"
            SELECT c.Title, c.Description,
            c.ListId, c.OwnerId, c.AssignedToId, c.StartDate, c.EndDate,
            c.CreatedDate, c.IsDeleted, c.[Order] FROM Cards c
            WHERE c.Id = @CardId

            SELECT u.Id, u.FirstName + ' ' + u.LastName FullName,
            CASE
                WHEN c.OwnerId = u.Id THEN 1
                WHEN c.AssignedToId = u.Id THEN 2
                ELSE 0
            END Type
            FROM Users u
            INNER JOIN Cards c ON c.AssignedToId = u.Id OR c.OwnerId = u.Id
            WHERE c.Id = @CardId

            SELECT ccl.Id, ccl.Title, ccli.Id as ItemId, ccli.Content, ccli.IsChecked FROM CardCheckLists ccl
            LEFT JOIN CardCheckListItems ccli ON ccli.CheckListId = ccl.Id
            WHERE ccl.CardId = @CardId

            SELECT cl.CardId CardId, bl.Id BoardLabelId, bl.Title, bl.ColorCode, bl.IsActive FROM CardLabels cl
            INNER JOIN BoardLabels bl ON bl.Id = cl.BoardLabelId
            WHERE cl.CardId = @CardId
            ORDER BY bl.Title ASC

            SELECT cc.Id, cc.Content, u.Id as UserId, CONCAT(u.FirstName,' ',u.LastName) as FullName FROM CardComments cc
            INNER JOIN Users u ON u.Id = cc.UserId
            WHERE cc.CardId = @CardId
            ";

            using var connection = _sqlConnectionFactory.GetConnection();

            var gridReader = await connection.QueryMultipleAsync(sql, new { CardId = cardId });
            var cardModel = await gridReader.ReadFirstOrDefaultAsync<CardModel>();
            cardModel.Users = (await gridReader.ReadAsync<CardUserModel>()).ToList();

            var cardCheckLists = (await gridReader.ReadAsync<CardCheckListQueryModel>()).ToList();

            var cardCheckListGrouping = cardCheckLists.GroupBy(x => x.Id);

            foreach (var group in cardCheckListGrouping)
            {
                var checkListItems = group.Where(x => x.ItemId != null).Select(x => new CardCheckListItemModel
                {
                    Id = x.ItemId ?? Guid.Empty,
                    Content = x.Content,
                    IsChecked = x.IsChecked
                });

                var cardCheckList = group.First();

                cardModel.CheckLists.Add(new CardCheckListModel
                {
                    Id = cardCheckList.Id,
                    CardId = cardId,
                    Items = checkListItems.ToList(),
                    Title = cardCheckList.Title
                });
            }


            cardModel.Labels = (await gridReader.ReadAsync<CardLabelModel>()).ToList();
            cardModel.Comments = (await gridReader.ReadAsync<CardCommentModel>()).ToList();

            return cardModel;
        }
    }
}
