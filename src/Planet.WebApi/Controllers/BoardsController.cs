using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Planet.Application.Features.Boards.Commands.AcceptInvitation;
using Planet.Application.Features.Boards.Commands.AddLabel;
using Planet.Application.Features.Boards.Commands.AddList;
using Planet.Application.Features.Boards.Commands.BoardListEdit;
using Planet.Application.Features.Boards.Commands.CreateBoard;
using Planet.Application.Features.Boards.Commands.EditBoard;
using Planet.Application.Features.Boards.Commands.InviteMember;
using Planet.Application.Features.Boards.Commands.RemoveList;
using Planet.Application.Features.Boards.Commands.RemoveMember;
using Planet.Application.Features.Boards.Queries.GetBoard;
using Planet.Application.Features.Boards.Queries.GetUserBoards;

namespace Planet.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class BoardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BoardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateBoardCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Edit(EditBoardCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("Members/Remove")]
        public async Task<IActionResult> RemoveMember(RemoveMemberCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("Lists/Add")]
        public async Task<IActionResult> AddList(AddListCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("Lists/Remove")]
        public async Task<IActionResult> RemoveList(RemoveListCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("Lists/Edit")]
        public async Task<IActionResult> EditList(BoardListEditCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("Members/Invite")]
        public async Task<IActionResult> InviteMember(InviteMemberCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpGet("Members/Invitation/{invitationKey}")]
        public async Task<IActionResult> AcceptInvitation(string invitationKey, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new AcceptInvitationCommand { InvitationKey = invitationKey }, cancellationToken);

            return Ok(response);
        }

        [HttpGet("UserBoards")]
        public async Task<IActionResult> GetUserBoards([FromQuery] GetUserBoardsQuery query, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(query, cancellationToken);

            return Ok(response);
        }

        [HttpGet("{boardId}")]
        public async Task<IActionResult> GetBoard(Guid boardId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetBoardQuery { BoardId = boardId }, cancellationToken);

            return Ok(response);
        }

        [HttpPost("Labels/Add")]
        public async Task<IActionResult> AddLabel(AddLabelCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }
    }
}
