using MediatR;
using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Cryptography;
using Planet.Application.Services.Repositories;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Users.Commands.ChangePassword
{
    internal class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ChangePasswordResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptographyService _cryptographyService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public ChangePasswordCommandHandler(IUserRepository userRepository, ICryptographyService cryptographyService, IUnitOfWork unitOfWork, IUserService userService)
        {
            _userRepository = userRepository;
            _cryptographyService = cryptographyService;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<ChangePasswordResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetUserId();
            var user = await _userRepository.FindAsync(userId);

            if (user is null)
            {
                return Response.Failure<ChangePasswordResponse>(OperationMessages.UserNotFound);
            }

            if (!_cryptographyService.VerifyPassword(request.OldPassword, user.Salt, user.Password))
            {
                return Response.Failure<ChangePasswordResponse>(OperationMessages.WrongOldPassword);
            }

            (string newPasswordHash, string newSalt) = _cryptographyService.HashPassword(request.Password);
            user.ChangePassword(newPasswordHash, newSalt);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Response.SuccessWithMessage<ChangePasswordResponse>(OperationMessages.PasswordChangedSuccessfully);
        }
    }
}
