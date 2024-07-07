using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Cards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Cards.Commands.AddCardCheckListItem
{
    internal class AddCardCheckListItemCommandHandler : RequestHandlerBase<AddCardCheckListItemCommand, AddCardCheckListItemResponse>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IUserService _userService;
        private readonly ICardRepository _cardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddCardCheckListItemCommandHandler(IBoardRepository boardRepository, IUserService userService, ICardRepository cardRepository, IUnitOfWork unitOfWork)
        {
            _boardRepository = boardRepository;
            _userService = userService;
            _cardRepository = cardRepository;
            _unitOfWork = unitOfWork;
        }

        public override async Task<AddCardCheckListItemResponse> Handle(AddCardCheckListItemCommand request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetUserId();
            var card = await _cardRepository.FindAsync(request.CardId);

            if (card == null)
            {
                return Response.Failure<AddCardCheckListItemResponse>(OperationMessages.CardNotFound);
            }

            if (!await _boardRepository.HasPermissionForListAsync(BoardPermissions.CreateAndEditCard, card.ListId, userId))
            {
                return Response.Failure<AddCardCheckListItemResponse>(OperationMessages.DoNotHavePermissionForEditingCard);
            }

            var checkListItemContent = CardCheckListItemContent.Create(request.Content);
            var checkListItemId = Guid.NewGuid();

            var item = CardCheckListItem.Create(checkListItemId, checkListItemContent, false, request.CheckListId);
            card.AddCardCheckListItem(item);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Response.SuccessWithBody<AddCardCheckListItemResponse>(new
            {
                request.CheckListId,
                checkListItemId,
                request.Content,
                IsChecked = false
            }, OperationMessages.EditedCardCheckListItemSuccessfully);
        }
    }
}
