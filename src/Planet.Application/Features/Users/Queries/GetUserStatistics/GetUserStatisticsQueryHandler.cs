using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;

namespace Planet.Application.Features.Users.Queries.GetUserStatistics
{
    public sealed class GetUserStatisticsQueryHandler : RequestHandlerBase<GetUserStatisticsQuery, GetUserStatisticsResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public GetUserStatisticsQueryHandler(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }
        public async override Task<GetUserStatisticsResponse> Handle(GetUserStatisticsQuery request, CancellationToken cancellationToken)
        {
            var userStatistics = await _userRepository.GetUserStatistics(_userService.GetUserId());

            return Response.SuccessWithBody<GetUserStatisticsResponse>(userStatistics);
        }
    }
}
