using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Cards.Commands.RemoveCardCheckList
{
    internal class RemoveCardCheckListCommandHandler : RequestHandlerBase<RemoveCardCheckListCommand, RemoveCardCheckListResponse>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IBoardRepository _boardRepository;

        public RemoveCardCheckListCommandHandler(ICardRepository cardRepository, IUnitOfWork unitOfWork, IUserService userService, IBoardRepository boardRepository)
        {
            _cardRepository = cardRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _boardRepository = boardRepository;
        }

        public override async Task<RemoveCardCheckListResponse> Handle(RemoveCardCheckListCommand request, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.FindAsync(request.CardId);

            if (card == null)
            {
                return Response.Failure<RemoveCardCheckListResponse>(OperationMessages.CardNotFound);
            }


            var listId = card.ListId;
            if (!await HasPermissionAsync(BoardPermissions.CreateAndEditCard, listId))
            {
                return Response.Failure<RemoveCardCheckListResponse>(OperationMessages.DoNotHavePermissionForRemoveCardCheckList);
            }

            card.RemoveCheckList(request.CheckListId);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Response.SuccessWithBody<RemoveCardCheckListResponse>(new
            {
                card.Id,
                request.CheckListId
            }
            , OperationMessages.RemovedCheckListFromCardSuccessfully);
        }

        private async Task<bool> HasPermissionAsync(BoardPermissions permission, Guid listId)
        {
            var userId = _userService.GetUserId();
            return await _boardRepository.HasPermissionForListAsync(permission, listId, userId);
        }
    }
}
