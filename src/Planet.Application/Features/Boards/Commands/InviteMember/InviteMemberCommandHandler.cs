using IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Caching;
using Planet.Application.Services.Cryptography;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Resources.OperationResources;

namespace Planet.Application.Features.Boards.Commands.InviteMember
{
    public class InviteMemberCommandHandler : RequestHandlerBase<InviteMemberCommand, InviteMemberResponse>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IUserService _userService;
        private readonly ICacheService _cacheService;
        private readonly ICryptographyService _cryptographyService;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InviteMemberCommandHandler(IBoardRepository boardRepository, IUserService userService, ICacheService cacheService, ICryptographyService cryptographyService, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _boardRepository = boardRepository;
            _userService = userService;
            _cacheService = cacheService;
            _cryptographyService = cryptographyService;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public override async Task<InviteMemberResponse> Handle(InviteMemberCommand request, CancellationToken cancellationToken)
        {
            var inviterId = _userService.GetUserId();
            var board = await _boardRepository.FindAsync(request.BoardId);

            if (board is null)
            {
                return Response.Failure<InviteMemberResponse>(OperationMessages.BoardNotFound);
            }

            bool canInvite = board.Members.FirstOrDefault(m => m.UserId == inviterId)?.Permissions.HasFlag(BoardPermissions.InviteMember) ?? false;

            if (!canInvite)
            {
                return Response.Failure<InviteMemberResponse>(OperationMessages.DoNotHavePermissionForBoardInviting);
            }

            int expireInMinutes = int.Parse(_configuration["Invitation:ExpireInMinutes"]);
            string urlParameter = $"{request.BoardId}~{DateTime.Now.AddMinutes(expireInMinutes)}";
            byte[] encryptedUrlParameter = _cryptographyService.Encrypt(_configuration["Invitation:Key"], urlParameter);
            string invitationKey = Base64Url.Encode(encryptedUrlParameter);


            return Response.SuccessWithBody<InviteMemberResponse>(new { Key = invitationKey }, OperationMessages.BoardInvitationUrlCreatedSuccessfully);
        }
    }
}
