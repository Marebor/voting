using Marebor.Voting.Core.Messaging.Commands;
using Marebor.Voting.ReadModel.Models;
using Marebor.Voting.ReadModel.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Marebor.Voting.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CandidatesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<IReadOnlyCollection<Candidate>> GetAllAsync(CancellationToken cancellationToken)
        {
            return _mediator.Send(new GetCandidates(), cancellationToken);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCandidateAsync([FromBody] AddCandidate command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);

            return Accepted();
        }
    }
}