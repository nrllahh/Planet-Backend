using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Cards.Commands.RemoveCardCheckListItem
{
    internal class RemoveCardCheckListItemCommandHandler : RequestHandlerBase<RemoveCardCheckListItemCommand, RemoveCardCheckListItemResponse>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IUserService _userService;
        private readonly ICardRepository _cardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveCardCheckListItemCommandHandler(IBoardRepository boardRepository, IUserService userService, ICardRepository cardRepository, IUnitOfWork unitOfWork)
        {
            _boardRepository = boardRepository;
            _userService = userService;
            _cardRepository = cardRepository;
            _unitOfWork = unitOfWork;
        }


        public override async Task<RemoveCardCheckListItemResponse> Handle(RemoveCardCheckListItemCommand request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetUserId();
            var card = await _cardRepository.FindAsync(request.CardId);

            if (card == null)
            {
                return Response.Failure<RemoveCardCheckListItemResponse>(OperationMessages.CardNotFound);
            }

            if (!await _boardRepository.HasPermissionForListAsync(BoardPermissions.CreateAndEditCard, card.ListId, userId))
            {
                return Response.Failure<RemoveCardCheckListItemResponse>(OperationMessages.DoNotHavePermissionForEditingCard);
            }

            card.RemoveCardCheckListItem(request.CheckListId, request.CheckListItemId);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Response.SuccessWithMessage<RemoveCardCheckListItemResponse>(OperationMessages.RemovedCardCheckListItemSuccessfully);
        }
    }
}
