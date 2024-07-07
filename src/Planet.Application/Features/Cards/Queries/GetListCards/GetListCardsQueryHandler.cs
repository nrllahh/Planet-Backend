using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Resources.OperationResources;

namespace Planet.Application.Features.Cards.Queries.GetListCards
{
    public sealed class GetListCardsQueryHandler : RequestHandlerBase<GetListCardsQuery, GetListCardsResponse>
    {

        private readonly IUserService _userService;
        private readonly ICardRepository _cardRepository;
        private readonly IBoardRepository _boardRepository;

        public GetListCardsQueryHandler(IUserService userService, ICardRepository cardRepository, IBoardRepository boardRepository)
        {
            _userService = userService;
            _cardRepository = cardRepository;
            _boardRepository = boardRepository;
        }
        public override async Task<GetListCardsResponse> Handle(GetListCardsQuery request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetUserId();
            bool hasPermission = await _boardRepository.HasPermissionForListAsync(BoardPermissions.View, request.ListId, userId);

            if (!hasPermission)
            {
                return Response.Failure<GetListCardsResponse>(OperationMessages.DoNotHavePermissionForViewingBoard);
            }

            var cards = await _cardRepository.GetListCardsAsync(request);


            return Response.SuccessWithBody<GetListCardsResponse>(cards);
        }
    }
}
