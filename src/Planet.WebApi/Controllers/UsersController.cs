using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Planet.Application.Features.Users.Commands.ChangePassword;
using Planet.Application.Features.Users.Commands.SignIn;
using Planet.Application.Features.Users.Commands.SignInRefresh;
using Planet.Application.Features.Users.Commands.SignUp;
using Planet.Application.Features.Users.Queries.GetUserStatistics;

namespace Planet.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(SignInCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(SignUpCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> SignInRefresh(SignInRefreshCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserStatistics(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetUserStatisticsQuery(), cancellationToken);

            return Ok(response);
        }
    }
}
