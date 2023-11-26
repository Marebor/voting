using Marebor.Voting.Core.Messaging.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Marebor.Voting.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VotesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> VoteAsync([FromBody] Vote command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);

            return Accepted();
        }
    }
}