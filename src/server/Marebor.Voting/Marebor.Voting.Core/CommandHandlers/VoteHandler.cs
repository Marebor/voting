using Marebor.Voting.Core.Messaging.Events;
using Marebor.Voting.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marebor.Voting.Core.CommandHandlers
{
    internal class VoteHandler : IRequestHandler<Messaging.Commands.Vote>
    {
        private readonly IMediator _mediator;
        private readonly ICandidateRepository _candidateRepository;
        private readonly IVoterRepository _voterRepository;
        private readonly IVoteRepository _voteRepository;

        public VoteHandler(IMediator mediator, ICandidateRepository candidateRepository, IVoterRepository voterRepository, IVoteRepository voteRepository)
        {
            _mediator = mediator;
            _candidateRepository = candidateRepository;
            _voterRepository = voterRepository;
            _voteRepository = voteRepository;
        }

        async Task IRequestHandler<Messaging.Commands.Vote>.Handle(Messaging.Commands.Vote request, CancellationToken cancellationToken)
        {
            var voter = await _voterRepository.GetVoterByNameAsync(request.VoterName, cancellationToken);

            if (voter == null)
            {
                await _mediator.Publish(new VoteFailed
                {
                    CommandId = request.CommandId,
                    Error = "Voter does not exist.",
                });

                return;
            }

            var candidate = await _candidateRepository.GetCandidateByNameAsync(request.CandidateName, cancellationToken);

            if (candidate == null)
            {
                await _mediator.Publish(new VoteFailed
                {
                    CommandId = request.CommandId,
                    Error = "Candidate does not exist.",
                });

                return;
            }

            var vote = await _voteRepository.GetVoteByVoterNameAsync(request.VoterName, cancellationToken);

            if (vote != null)
            {
                await _mediator.Publish(new VoteFailed
                {
                    CommandId = request.CommandId,
                    Error = "Voter has already voted.",
                });

                return;
            }

            vote = await _voteRepository.CreateVoteAsync(new Models.Vote
                { 
                    VoterName = request.VoterName,
                    CandidateName = request.CandidateName,
                }, 
                cancellationToken);

            await _mediator.Publish(new VoteAdded
            {
                CommandId = request.CommandId,
                VoterName = vote.VoterName,
                CandidateName = vote.CandidateName,
            });
        }
    }
}
