using MediatR.Wrappers;
using Planet.Application.Common;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Application.Features.Boards.Commands.BoardListEdit
{
    internal class BoardListEditCommandHandler : RequestHandlerBase<BoardListEditCommand, BoardListEditResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBoardRepository _boardRepository;

        public BoardListEditCommandHandler(IBoardRepository boardRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _boardRepository = boardRepository;
        }
        public override async Task<BoardListEditResponse> Handle(BoardListEditCommand request, CancellationToken cancellationToken)
        {
            var boardId = request.BoardId;
            var listId = request.ListId;
            var title = BoardTitle.Create(request.Title);
            var order = request.Order;

            var board = await _boardRepository.FindAsync(boardId);

            if (board == null)
            {
                return Response.Failure<BoardListEditResponse>(OperationMessages.BoardNotFound);
            }

            board.EditList(listId, title, order);

            await _unitOfWork.SaveChangesAsync();

            return Response.SuccessWithMessage<BoardListEditResponse>(OperationMessages.BoardListEditedSuccesfully);



        }
    }
}
