using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Cards.Commands.AssignUser
{
    internal class AssignUserCommandHandler : RequestHandlerBase<AssignUserCommand, AssignUserResponse>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IBoardRepository _boardRepository;

        public AssignUserCommandHandler(ICardRepository cardRepository, IUnitOfWork unitOfWork, IUserService userService, IBoardRepository boardRepository)
        {
            _cardRepository = cardRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _boardRepository = boardRepository;
        }

        public override async Task<AssignUserResponse> Handle(AssignUserCommand request, CancellationToken cancellationToken)
        {
            var cardId = request.CardId;
            var card = await _cardRepository.FindAsync(cardId);

            if (card == null)
            {
                return Response.Failure<AssignUserResponse>(OperationMessages.CardNotFound);
            }

            if (!await HasPermissionAsync(BoardPermissions.AssignCard, card.ListId))
            {
                return Response.Failure<AssignUserResponse>(OperationMessages.DoNotHavePermissionForAssigningUserToCard);
            }

            card.AssignUser(request.UserId);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Response.Success<AssignUserResponse>();
        }

        private async Task<bool> HasPermissionAsync(BoardPermissions permission, Guid listId)
        {
            var userId = _userService.GetUserId();
            return await _boardRepository.HasPermissionForListAsync(permission, listId, userId);
        }
    }
}
