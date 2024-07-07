using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Boards.Commands.EditBoard
{
    internal class EditBoardCommandHandler : RequestHandlerBase<EditBoardCommand, EditBoardResponse>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public EditBoardCommandHandler(IBoardRepository boardRepository, IUnitOfWork unitOfWork, IUserService userService)
        {
            _boardRepository = boardRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public override async Task<EditBoardResponse> Handle(EditBoardCommand request, CancellationToken cancellationToken)
        {
            var title = BoardTitle.Create(request.Title);
            var description = BoardDescription.Create(request.Description);

            var board = await _boardRepository.FindAsync(request.BoardId);

            if (board is null)
            {
                return Response.Failure<EditBoardResponse>(OperationMessages.BoardNotFound);
            }

            if (!HasPermissionToEditBoard(board))
            {
                return Response.Failure<EditBoardResponse>(OperationMessages.DoNotHavePermissionForEditingBoard);
            }

            board.ChangeBoardTitle(title);
            board.ChangeBoardDescription(description);

            await _unitOfWork.SaveChangesAsync();

            return Response.SuccessWithMessage<EditBoardResponse>(OperationMessages.EditedBoardSuccessfully);
        }

        private bool HasPermissionToEditBoard(Board board)
        {
            var userId = _userService.GetUserId();

            return board.Members.FirstOrDefault(m => m.UserId == userId)?.Permissions.HasFlag(BoardPermissions.ChangeSpecs) ?? false;
        }
    }
}
