using Planet.Application.Common;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Cards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Boards.Commands.AddList
{
    internal class AddListCommandHandler : RequestHandlerBase<AddListCommand, AddListResponse>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddListCommandHandler(IBoardRepository boardRepository, IUnitOfWork unitOfWork)
        {
            _boardRepository = boardRepository;
            _unitOfWork = unitOfWork;
        }

        public override async Task<AddListResponse> Handle(AddListCommand request, CancellationToken cancellationToken)
        {
            var boardId = request.BoardId;
            var title = BoardTitle.Create(request.Title);
            var order = request.Order;
            var listId = Guid.NewGuid();
            var board = await _boardRepository.FindAsync(boardId);

            var boardList = BoardList.Create(listId, boardId, title, order);
            board.AddList(boardList);
            await _unitOfWork.SaveChangesAsync();

            return Response.SuccessWithBody<AddListResponse>(new
            {
                ListId = listId,
                Title = title.Value,
            }, OperationMessages.AddedListSuccessfully);
        }

    }
}
