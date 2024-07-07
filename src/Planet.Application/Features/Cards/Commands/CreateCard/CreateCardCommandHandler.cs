using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Cards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Cards.Commands.CreateCard
{
    internal class CreateCardCommandHandler : RequestHandlerBase<CreateCardCommand, CreateCardResponse>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IBoardRepository _boardRepository;

        public CreateCardCommandHandler(ICardRepository cardRepository, IUnitOfWork unitOfWork, IUserService userService, IBoardRepository boardRepository)
        {
            _cardRepository = cardRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _boardRepository = boardRepository;
        }

        public override async Task<CreateCardResponse> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            if (!await HasPermissionAsync(BoardPermissions.CreateAndEditCard, request.ListId))
            {
                return Response.Failure<CreateCardResponse>(OperationMessages.DoNotHavePermissionForCreatingCard);
            }

            var cardId = Guid.NewGuid();
            var ownerId = _userService.GetUserId();
            var createdDate = DateTime.Now;
            var title = CardTitle.Create(request.Title);
            var card = Card.Create(cardId, request.ListId, title, ownerId, createdDate, request.Order);

            await _cardRepository.CreateAsync(card);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Response.SuccessWithBody<CreateCardResponse>(new
            {
                CardId = cardId,
                Title = title.Value,
            }, OperationMessages.CreatedCardSuccessfully);
        }

        private Task<bool> HasPermissionAsync(BoardPermissions permission, Guid listId)
        {
            var userId = _userService.GetUserId();
            return _boardRepository.HasPermissionForListAsync(permission, listId, userId);
        }
    }
}
