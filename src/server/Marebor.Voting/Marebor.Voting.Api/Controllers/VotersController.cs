using Marebor.Voting.Core.Messaging.Commands;
using Marebor.Voting.ReadModel.Models;
using Marebor.Voting.ReadModel.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Marebor.Voting.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VotersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VotersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<IReadOnlyCollection<Voter>> GetAllAsync(CancellationToken cancellationToken)
        {
            return _mediator.Send(new GetVoters(), cancellationToken);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddVoterAsync([FromBody] AddVoter command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);

            return Accepted();
        }
    }
}