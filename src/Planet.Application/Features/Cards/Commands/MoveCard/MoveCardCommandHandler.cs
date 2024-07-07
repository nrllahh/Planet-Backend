using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;
namespace Planet.Application.Features.Cards.Commands.MoveTo
{
    internal class MoveCardCommandHandler : RequestHandlerBase<MoveCardCommand, MoveCardResponse>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IBoardRepository _boardRepository;

        public MoveCardCommandHandler(ICardRepository cardRepository, IUnitOfWork unitOfWork, IUserService userService, IBoardRepository boardRepository)
        {
            _cardRepository = cardRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _boardRepository = boardRepository;
        }

        public override async Task<MoveCardResponse> Handle(MoveCardCommand request, CancellationToken cancellationToken)
        {
            if (!await HasPermissionAsync(BoardPermissions.CreateAndEditCard, request.NewListId))
            {
                return Response.Failure<MoveCardResponse>(OperationMessages.DoNotHavePermissionForMovingCard);
            }

            var card = await _cardRepository.FindAsync(request.CardId);

            card.MoveToList(request.NewListId, request.NewOrder);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Response.SuccessWithBody<MoveCardResponse>(new
            {
                CardId = request.CardId,
                NewListId = request.NewListId,
                NewOrder = request.NewOrder
            }, OperationMessages.MovedCardSuccessfully);
        }

        private async Task<bool> HasPermissionAsync(BoardPermissions permission, Guid listId)
        {
            var userId = _userService.GetUserId();
            return await _boardRepository.HasPermissionForListAsync(permission, listId, userId);
        }
    }
}
