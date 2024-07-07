using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Boards.Commands.RemoveList
{
    public class RemoveListCommandHandler : RequestHandlerBase<RemoveListCommand, RemoveListResponse>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public RemoveListCommandHandler(IBoardRepository boardRepository, IUnitOfWork unitOfWork, IUserService userService)
        {
            _boardRepository = boardRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public override async Task<RemoveListResponse> Handle(RemoveListCommand request, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.FindAsync(request.BoardId);

            if (!HasPermissionToRemoveList(board))
            {
                return Response.Failure<RemoveListResponse>(OperationMessages.DoNotHavePermissionForManagingBoardLists);
            }

            bool hasAnyCard = await _boardRepository.HasBoardListAnyCard(request.ListId);

            if (hasAnyCard)
            {
                return Response.Failure<RemoveListResponse>(OperationMessages.CanNotRemoveBoardListThatContainsCard);
            }

            var boardList = board.Lists.FirstOrDefault(l => l.Id == request.ListId);

            if (boardList is null)
            {
                return Response.Failure<RemoveListResponse>(OperationMessages.BoardListNotFound);
            }

            board.RemoveList(boardList);

            await _unitOfWork.SaveChangesAsync();

            return Response.SuccessWithMessage<RemoveListResponse>(OperationMessages.RemovedBoardListSuccessfully);
        }

        private bool HasPermissionToRemoveList(Board board)
        {
            var userId = _userService.GetUserId();

            return board.Members.FirstOrDefault(m => m.UserId == userId)?.Permissions.HasFlag(BoardPermissions.ManageLists) ?? false;
        }
    }
}
