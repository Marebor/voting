using Marebor.Voting.Core.Messaging.Events;
using Marebor.Voting.ReadModel.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marebor.Voting.ReadModel.EventHandlers
{
    internal class VoteAddedHandler : INotificationHandler<VoteAdded>
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IVoterRepository _voterRepository;

        public VoteAddedHandler(ICandidateRepository candidateRepository, IVoterRepository voterRepository)
        {
            _candidateRepository = candidateRepository;
            _voterRepository = voterRepository;
        }

        public async Task Handle(VoteAdded notification, CancellationToken cancellationToken)
        {
            var candidate = await _candidateRepository.GetCandidateByNameAsync(notification.CandidateName, cancellationToken);
            var voter = await _voterRepository.GetVoterByNameAsync(notification.VoterName, cancellationToken);

            candidate.VotesCount++;
            voter.HasVoted = true;

            await _candidateRepository.CreateOrUpdateCandidateAsync(candidate, cancellationToken);
            await _voterRepository.CreateOrUpdateVoterAsync(voter, cancellationToken);
        }
    }
}
