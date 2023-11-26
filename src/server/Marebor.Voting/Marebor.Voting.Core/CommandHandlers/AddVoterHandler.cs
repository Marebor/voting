using Marebor.Voting.Core.Messaging.Commands;
using Marebor.Voting.Core.Messaging.Events;
using Marebor.Voting.Core.Models;
using Marebor.Voting.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marebor.Voting.Core.CommandHandlers
{
    internal class AddVoterHandler : IRequestHandler<AddVoter>
    {
        private readonly IMediator _mediator;
        private readonly IVoterRepository _voterRepository;

        public AddVoterHandler(IMediator mediator, IVoterRepository voterRepository)
        {
            _mediator = mediator;
            _voterRepository = voterRepository;
        }

        async Task IRequestHandler<AddVoter>.Handle(AddVoter request, CancellationToken cancellationToken)
        {
            var voter = await _voterRepository.GetVoterByNameAsync(request.Name, cancellationToken);

            if (voter != null)
            {
                await _mediator.Publish(new VoterAdditionFailed
                {
                    CommandId = request.CommandId,
                    Error = "Voter already exists.",
                });

                return;
            }

            voter = await _voterRepository.CreateVoterAsync(new Voter { Name = request.Name }, cancellationToken);

            await _mediator.Publish(new VoterAdded
            {
                CommandId = request.CommandId,
                Name = voter.Name,
            });
        }
    }
}
