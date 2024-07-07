using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Boards.Commands.RemoveMember
{
    public sealed class RemoveMemberCommandHandler : RequestHandlerBase<RemoveMemberCommand, RemoveMemberResponse>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public RemoveMemberCommandHandler(IBoardRepository boardRepository, IUnitOfWork unitOfWork, IUserService userService)
        {
            _boardRepository = boardRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public override async Task<RemoveMemberResponse> Handle(RemoveMemberCommand request, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.FindAsync(request.BoardId);

            if (board is null)
            {
                return Response.Failure<RemoveMemberResponse>(OperationMessages.BoardNotFound);
            }

            if (!HasPermissionToRemoveMember(board))
            {
                return Response.Failure<RemoveMemberResponse>(OperationMessages.DoNotHavePermissionForManagingBoardMembers);
            }

            if (IsRemovedUserBoardOwner(board, request.UserId))
            {
                return Response.Failure<RemoveMemberResponse>(OperationMessages.CanNotRemoveBoardOwner);
            }

            var boardMember = board.Members.FirstOrDefault(m => m.UserId == request.UserId);

            board.RemoveMember(boardMember);

            await _unitOfWork.SaveChangesAsync();

            return Response.SuccessWithMessage<RemoveMemberResponse>(OperationMessages.RemovedBoardMemberSuccessfully);
        }

        private bool HasPermissionToRemoveMember(Board board)
        {
            var userId = _userService.GetUserId();

            return board.Members.Any(m => m.UserId == userId && m.Permissions.HasFlag(BoardPermissions.ManageMembers));
        }

        private bool IsRemovedUserBoardOwner(Board board, Guid removedId)
        {
            return board.OwnerId == removedId;
        }
    }
}
