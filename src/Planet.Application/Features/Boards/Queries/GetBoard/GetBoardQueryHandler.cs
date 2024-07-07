using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Resources.OperationResources;

namespace Planet.Application.Features.Boards.Queries.GetBoard
{
    public sealed class GetBoardQueryHandler : RequestHandlerBase<GetBoardQuery, GetBoardResponse>
    {
        private readonly IUserService _userService;
        private readonly IBoardRepository _boardRepository;

        public GetBoardQueryHandler(IUserService userService, IBoardRepository boardRepository)
        {
            _userService = userService;
            _boardRepository = boardRepository;
        }

        public async override Task<GetBoardResponse> Handle(GetBoardQuery request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetUserId();
            bool hasPermission = await _boardRepository.HasPermissionAsync(BoardPermissions.View, request.BoardId, userId);

            if (!hasPermission)
            {
                return Response.Failure<GetBoardResponse>(OperationMessages.DoNotHavePermissionForViewingBoard);
            }

            var boardModel = await _boardRepository.GetBoardAsync(request.BoardId);

            return Response.SuccessWithBody<GetBoardResponse>(boardModel);
        }
    }
}
