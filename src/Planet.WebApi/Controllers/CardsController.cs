using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Planet.Application.Features.Cards.Commands.AddCardCheckList;
using Planet.Application.Features.Cards.Commands.AddCardCheckListItem;
using Planet.Application.Features.Cards.Commands.AddCardComment;
using Planet.Application.Features.Cards.Commands.AddLabel;
using Planet.Application.Features.Cards.Commands.AssignUser;
using Planet.Application.Features.Cards.Commands.CreateCard;
using Planet.Application.Features.Cards.Commands.EditCardCheckListItem;
using Planet.Application.Features.Cards.Commands.EditCardCheckListTitle;
using Planet.Application.Features.Cards.Commands.EditCardDescription;
using Planet.Application.Features.Cards.Commands.EditDate;
using Planet.Application.Features.Cards.Commands.EditTitle;
using Planet.Application.Features.Cards.Commands.MoveTo;
using Planet.Application.Features.Cards.Commands.RemoveCard;
using Planet.Application.Features.Cards.Commands.RemoveCardCheckList;
using Planet.Application.Features.Cards.Commands.RemoveCardCheckListItem;
using Planet.Application.Features.Cards.Commands.RemoveLabel;
using Planet.Application.Features.Cards.Queries.GetCardInfo;
using Planet.Application.Features.Cards.Queries.GetListCards;

namespace Planet.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateCardCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> EditDescriptiion(EditCardDescriptionCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> EditTitle(EditTitleCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);

        }

        [HttpPost("Labels/Add")]
        public async Task<IActionResult> AddLabel(AddLabelCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("Labels/Remove")]
        public async Task<IActionResult> RemoveLabel(RemoveLabelCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> EditCardDate(EditDateCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("Comments/Add")]
        public async Task<IActionResult> AddCardComment(AddCardCommentCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("CheckLists/Add")]
        public async Task<IActionResult> AddCardCheckList(AddCardCheckListCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("CheckLists/Edit")]
        public async Task<IActionResult> EditCardCheckListTitle(EditCardCheckListTitleCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("CheckLists/Remove")]
        public async Task<IActionResult> RemoveCardCheckList(RemoveCardCheckListCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("CheckLists/Items/Remove")]
        public async Task<IActionResult> RemoveCardCheckListItem(RemoveCardCheckListItemCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("CheckLists/Items/Add")]
        public async Task<IActionResult> AddCardCheckListItem(AddCardCheckListItemCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("CheckLists/Items/Edit")]
        public async Task<IActionResult> EditCardCheckListItem(EditCardCheckListItemCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpGet("{cardId}")]
        public async Task<IActionResult> GetCardInfo(Guid cardId, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(new GetCardInfoQuery() { CardId = cardId }, cancellationToken);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AssignUser(AssignUserCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListCards([FromQuery] GetListCardsQuery query, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(query, cancellationToken);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> MoveCard(MoveCardCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RemoveCard(RemoveCardCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }
    }
}
