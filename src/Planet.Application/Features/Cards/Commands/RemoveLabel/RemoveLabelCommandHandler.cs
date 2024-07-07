using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Cards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Cards.Commands.RemoveLabel
{
    public sealed class RemoveLabelCommandHandler : RequestHandlerBase<RemoveLabelCommand, RemoveLabelResponse>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IBoardRepository _boardRepository;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveLabelCommandHandler(ICardRepository cardRepository, IBoardRepository boardRepository, IUnitOfWork unitOfWork, IUserService userService)
        {
            _cardRepository = cardRepository;
            _boardRepository = boardRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async override Task<RemoveLabelResponse> Handle(RemoveLabelCommand request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetUserId();
            var card = await _cardRepository.FindAsync(request.CardId);

            if (card == null)
            {
                return Response.Failure<RemoveLabelResponse>(OperationMessages.CardNotFound);
            }

            if (!await _boardRepository.HasPermissionForListAsync(BoardPermissions.CreateAndEditCard, card.ListId, userId))
            {
                return Response.Failure<RemoveLabelResponse>(OperationMessages.DoNotHavePermissionForEditingCard);
            }

            card.RemoveLabel(CardLabel.Create(request.CardId, request.BoardLabelId));

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Response.Success<RemoveLabelResponse>();
        }
    }
}
