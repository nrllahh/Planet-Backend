using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Cards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Cards.Commands.EditCardCheckListTitle
{
    internal class EditCardCheckListTitleCommandHandler : RequestHandlerBase<EditCardCheckListTitleCommand, EditCardCheckListTitleResponse>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBoardRepository _boardRepository;
        public EditCardCheckListTitleCommandHandler(ICardRepository cardRepository, IUserService userService, IUnitOfWork unitOfWork, IBoardRepository boardRepository)
        {
            _cardRepository = cardRepository;
            _userService = userService;
            _unitOfWork = unitOfWork;
            _boardRepository = boardRepository;
        }

        public override async Task<EditCardCheckListTitleResponse> Handle(EditCardCheckListTitleCommand request, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.FindAsync(request.CardId);

            if (card == null)
            {
                return Response.Failure<EditCardCheckListTitleResponse>(OperationMessages.CardNotFound);
            }

            var listId = card.ListId;
            if (!await HasPermissionAsync(BoardPermissions.CreateAndEditCard, listId))
            {
                return Response.Failure<EditCardCheckListTitleResponse>(OperationMessages.DoNotHavePermissionForEditCardCheckListTitle);
            }

            card.EditCheckListTitle(request.CheckListId, CardTitle.Create(request.NewTitle));
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Response.SuccessWithBody<EditCardCheckListTitleResponse>(new
            {
                CardId = card.Id,
                CheckListId = request.CheckListId,
                NewTitle = request.NewTitle
            }, OperationMessages.EditedCheckListTitleSuccessfully);
        }

        private async Task<bool> HasPermissionAsync(BoardPermissions permission, Guid listId)
        {
            var userId = _userService.GetUserId();
            return await _boardRepository.HasPermissionForListAsync(permission, listId, userId);
        }
    }
}


