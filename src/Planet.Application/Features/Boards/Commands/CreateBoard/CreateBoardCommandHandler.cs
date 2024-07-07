using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Boards.Commands.CreateBoard
{
    internal class CreateBoardCommandHandler : RequestHandlerBase<CreateBoardCommand, CreateBoardResponse>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public CreateBoardCommandHandler(IBoardRepository boardRepository, IUnitOfWork unitOfWork, IUserService userService)
        {
            _boardRepository = boardRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }
        public override async Task<CreateBoardResponse> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
        {
            var title = BoardTitle.Create(request.Title);
            var description = BoardDescription.Create(request.Description);
            var modules = request.Modules;
            var createdDate = DateTime.Now;
            var boardId = Guid.NewGuid();
            var ownerId = _userService.GetUserId();

            if (ownerId == Guid.Empty)
            {
                return Response.Failure<CreateBoardResponse>(OperationMessages.UserNotFound);
            }

            var board = Board.Create(boardId, title, description, modules, createdDate, ownerId);

            await _boardRepository.CreateAsync(board);
            await _unitOfWork.SaveChangesAsync();

            return Response.SuccessWithBody<CreateBoardResponse>(new { BoardId = board.Id },
                string.Format(OperationMessages.CreatedBoardSuccessfully, board.Title.Value));
        }
    }
}
