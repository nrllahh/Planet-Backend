using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Boards.Commands.AddLabel
{
    internal class AddLabelCommandHandler : RequestHandlerBase<AddLabelCommand, AddLabelResponse>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public AddLabelCommandHandler(IBoardRepository boardRepository, IUnitOfWork unitOfWork, IUserService userService)
        {
            _boardRepository = boardRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }
        public override async Task<AddLabelResponse> Handle(AddLabelCommand request, CancellationToken cancellationToken)
        {
            if (!await HasPermissionAsync(BoardPermissions.CreateAndEditCard, request.BoardId))
            {
                return Response.Failure<AddLabelResponse>(OperationMessages.DoNotHavePermissionForEditCardDescription);
            }

            var boardId = request.BoardId;
            var title = BoardTitle.Create(request.Title);
            var colorCode = BoardLabelColor.Create(request.ColorCode);
            var labelId = Guid.NewGuid();
            var board = await _boardRepository.FindAsync(boardId);

            var boardLabel = BoardLabel.Create(labelId, boardId, colorCode, title);
            board.AddLabel(boardLabel);
            await _unitOfWork.SaveChangesAsync();
            return Response.SuccessWithMessage<AddLabelResponse>(OperationMessages.AddedLabelSuccessfully);
        }
        private Task<bool> HasPermissionAsync(BoardPermissions permission, Guid boardId)
        {
            var userId = _userService.GetUserId();
            return _boardRepository.HasPermissionAsync(permission, boardId, userId);
        }
    }
}
