using Marebor.Voting.Core.Messaging.Events;
using Marebor.Voting.ReadModel.Models;
using Marebor.Voting.ReadModel.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marebor.Voting.ReadModel.EventHandlers
{
    internal class CandidateAddedHandler : INotificationHandler<CandidateAdded>
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateAddedHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public Task Handle(CandidateAdded notification, CancellationToken cancellationToken)
        {
            return _candidateRepository.CreateOrUpdateCandidateAsync(new Candidate
                {
                    Name = notification.Name,
                },
                cancellationToken);
        }
    }
}
