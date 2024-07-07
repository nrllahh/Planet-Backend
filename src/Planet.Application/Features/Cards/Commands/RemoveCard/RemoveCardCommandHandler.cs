using IdentityModel.Client;
using MediatR.Wrappers;
using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Planet.Application.Features.Cards.Commands.RemoveCard
{
    internal class RemoveCardCommandHandler : RequestHandlerBase<RemoveCardCommand, RemoveCardResponse>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IBoardRepository _boardRepository;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveCardCommandHandler(ICardRepository cardRepository, IBoardRepository boardRepository, IUserService userService, IUnitOfWork unitOfWork)
        {
            _cardRepository = cardRepository;
            _boardRepository = boardRepository;
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        public async override Task<RemoveCardResponse> Handle(RemoveCardCommand request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetUserId();
            var card = await _cardRepository.FindAsync(request.CardId);

            if (card == null)
            {
                return Response.Failure<RemoveCardResponse>(OperationMessages.CardNotFound);
            }

            if (!await _boardRepository.HasPermissionForListAsync(BoardPermissions.CreateAndEditCard, card.ListId, userId))
            {
                return Response.Failure<RemoveCardResponse>(OperationMessages.DoNotHavePermissionForEditingCard);
            }

            card.Remove();

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Response.Success<RemoveCardResponse>();
        }
    }
}
