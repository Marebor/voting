using Marebor.Voting.Core.Messaging.Events;
using Marebor.Voting.ReadModel.Models;
using Marebor.Voting.ReadModel.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marebor.Voting.ReadModel.EventHandlers
{
    internal class VoterAddedHandler : INotificationHandler<VoterAdded>
    {
        private readonly IVoterRepository _voterRepository;

        public VoterAddedHandler(IVoterRepository voterRepository)
        {
            _voterRepository = voterRepository;
        }

        public Task Handle(VoterAdded notification, CancellationToken cancellationToken)
        {
            return _voterRepository.CreateOrUpdateVoterAsync(new Voter
                {
                    Name = notification.Name,
                },
                cancellationToken);
        }
    }
}
