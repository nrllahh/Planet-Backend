using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Cards.Commands.EditCardCheckListItem
{
    internal class EditCardCheckListItemCommandHandler : RequestHandlerBase<EditCardCheckListItemCommand, EditCardCheckListItemResponse>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IUserService _userService;
        private readonly ICardRepository _cardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EditCardCheckListItemCommandHandler(IBoardRepository boardRepository, IUserService userService, ICardRepository cardRepository, IUnitOfWork unitOfWork)
        {
            _boardRepository = boardRepository;
            _userService = userService;
            _cardRepository = cardRepository;
            _unitOfWork = unitOfWork;
        }

        public override async Task<EditCardCheckListItemResponse> Handle(EditCardCheckListItemCommand request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetUserId();
            var card = await _cardRepository.FindAsync(request.CardId);

            if (card == null)
            {
                return Response.Failure<EditCardCheckListItemResponse>(OperationMessages.CardNotFound);
            }

            if (!await _boardRepository.HasPermissionForListAsync(BoardPermissions.CreateAndEditCard, card.ListId, userId))
            {
                return Response.Failure<EditCardCheckListItemResponse>(OperationMessages.DoNotHavePermissionForEditingCard);
            }

            card.EditCardCheckListItem(request.CheckListId, request.CheckListItemId, request.Content, request.IsChecked);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Response.SuccessWithBody<EditCardCheckListItemResponse>(new
            {
                request.CardId,
                request.CheckListId,
                request.CheckListItemId,
                request.Content,
                request.IsChecked
            }, OperationMessages.EditedCardCheckListItemSuccessfully);
        }
    }
}
