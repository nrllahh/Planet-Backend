﻿using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Cards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Cards.Commands.EditTitle
{
    internal class EditTitleCommandHandler : RequestHandlerBase<EditTitleCommand, EditTitleResponse>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBoardRepository _boardRepository;

        public EditTitleCommandHandler(ICardRepository cardRepository, IUserService userService, IUnitOfWork unitOfWork, IBoardRepository boardRepository)
        {
            _cardRepository = cardRepository;
            _userService = userService;
            _unitOfWork = unitOfWork;
            _boardRepository = boardRepository;
        }

        public override async Task<EditTitleResponse> Handle(EditTitleCommand request, CancellationToken cancellationToken)
        {
            var cardId = request.CardId;
            var card = await _cardRepository.FindAsync(cardId);
            var listId = card.ListId;
            if (!await HasPermissionAsync(BoardPermissions.CreateAndEditCard, listId))
            {
                return Response.Failure<EditTitleResponse>(OperationMessages.DoNotHavePermissionForEditDateCard);
            }
            var title = CardTitle.Create(request.Title);
            card.ChangeCardTitle(title);
            await _unitOfWork.SaveChangesAsync();
            return Response.SuccessWithBody<EditTitleResponse>(new
            {
                CardId = cardId
            }, OperationMessages.EditedCardTitleSuccessfully);
        }
        private async Task<bool> HasPermissionAsync(BoardPermissions permission, Guid listId)
        {
            var userId = _userService.GetUserId();
            return await _boardRepository.HasPermissionForListAsync(permission, listId, userId);
        }
    }
}