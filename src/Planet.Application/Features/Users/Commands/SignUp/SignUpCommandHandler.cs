using Planet.Application.Common;
using Planet.Application.Services.Cryptography;
using Planet.Application.Services.Repositories;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;
using Planet.Domain.Users;

namespace Planet.Application.Features.Users.Commands.SignUp
{
    internal class SignUpCommandHandler : RequestHandlerBase<SignUpCommand, SignUpResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptographyService _cryptographyService;
        private readonly IUnitOfWork _unitOfWork;

        public SignUpCommandHandler(IUserRepository userRepository, ICryptographyService cryptographyService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _cryptographyService = cryptographyService;
            _unitOfWork = unitOfWork;
        }

        public override async Task<SignUpResponse> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var firstName = FirstName.Create(request.FirstName);
            var lastName = LastName.Create(request.LastName);
            var email = Email.Create(request.Email);
            var userId = Guid.NewGuid();
            var createdDate = DateTime.Now;

            (string passwordHash, string salt) = _cryptographyService.HashPassword(request.Password);

            var user = User.Create(userId, email, passwordHash, salt, firstName, lastName, createdDate);

            await _userRepository.CreateAsync(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Response.SuccessWithMessage<SignUpResponse>(OperationMessages.SignedUpSuccessfully);
        }
    }
}
