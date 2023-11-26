using Marebor.Voting.Core.Messaging.Commands;
using Marebor.Voting.Core.Messaging.Events;
using Marebor.Voting.Core.Models;
using Marebor.Voting.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marebor.Voting.Core.CommandHandlers
{
    internal class AddCandidateHandler : IRequestHandler<AddCandidate>
    {
        private readonly IMediator _mediator;
        private readonly ICandidateRepository _candidateRepository;

        public AddCandidateHandler(IMediator mediator, ICandidateRepository candidateRepository)
        {
            _mediator = mediator;
            _candidateRepository = candidateRepository;
        }

        async Task IRequestHandler<AddCandidate>.Handle(AddCandidate request, CancellationToken cancellationToken)
        {
            var candidate = await _candidateRepository.GetCandidateByNameAsync(request.Name, cancellationToken);

            if (candidate != null)
            {
                await _mediator.Publish(new CandidateAdditionFailed
                {
                    CommandId = request.CommandId,
                    Error = "Candidate already exists."
                });

                return;
            }

            candidate = await _candidateRepository.CreateCandidateAsync(new Candidate { Name = request.Name }, cancellationToken);

            await _mediator.Publish(new CandidateAdded
            {
                CommandId = request.CommandId,
                Name = candidate.Name,
            });
        }
    }
}
