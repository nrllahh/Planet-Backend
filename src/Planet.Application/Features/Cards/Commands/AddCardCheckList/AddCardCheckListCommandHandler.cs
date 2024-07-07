using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Cards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Cards.Commands.AddCardCheckList
{
    public class AddCardCheckListCommandHandler : RequestHandlerBase<AddCardCheckListCommand, AddCardCheckListResponse>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IBoardRepository _boardRepository;

        public AddCardCheckListCommandHandler(ICardRepository cardRepository, IUnitOfWork unitOfWork, IUserService userService, IBoardRepository boardRepository)
        {
            _cardRepository = cardRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _boardRepository = boardRepository;
        }
        public override async Task<AddCardCheckListResponse> Handle(AddCardCheckListCommand request, CancellationToken cancellationToken)
        {
            var cardId = request.CardId;
            var card = await _cardRepository.FindAsync(cardId);
            var listId = card.ListId;
            if (!await HasPermissionAsync(BoardPermissions.CreateAndEditCard, listId))
            {
                return Response.Failure<AddCardCheckListResponse>(OperationMessages.DoNotHavePermissionForAddCardCheckList);
            }
            var id = Guid.NewGuid();

            var title = CardTitle.Create(request.Title);


            var cardCheckList = CardCheckList.Create(id, cardId, title);
            card.AddCheckList(cardCheckList);
            await _unitOfWork.SaveChangesAsync(cancellationToken);


            return Response.SuccessWithBody<AddCardCheckListResponse>(new
            {
                CardId = cardId,
                Title = title.Value,
                CheckListId = cardCheckList.Id
            }, OperationMessages.AddedCheckListToCardSuccessfully);
        }

        private async Task<bool> HasPermissionAsync(BoardPermissions permission, Guid listId)
        {
            var userId = _userService.GetUserId();
            return await _boardRepository.HasPermissionForListAsync(permission, listId, userId);
        }

    }

}
