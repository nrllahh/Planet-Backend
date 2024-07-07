using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;

namespace Planet.Application.Features.Boards.Queries.GetUserBoards
{
    public sealed class GetUserBoardsQueryHandler : RequestHandlerBase<GetUserBoardsQuery, GetUserBoardsResponse>
    {
        private readonly IUserService _userService;
        private readonly IBoardRepository _boardRepository;

        public GetUserBoardsQueryHandler(IUserService userService, IBoardRepository boardRepository)
        {
            _userService = userService;
            _boardRepository = boardRepository;
        }

        public override async Task<GetUserBoardsResponse> Handle(GetUserBoardsQuery request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetUserId();
            var userBoards = await _boardRepository.GetUserBoardsAsync(request, userId);

            return Response.SuccessWithBody<GetUserBoardsResponse>(userBoards);
        }
    }
}
