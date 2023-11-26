using Marebor.Voting.Core.Models;
using Marebor.Voting.Core.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Marebor.Voting.Core.Infrastructure.Repositories
{
    // for simplicity - repo without validations and multi-threading
    internal class InMemoryRepository : ICandidateRepository, IVoterRepository, IVoteRepository
    {
        private readonly Dictionary<string, Candidate> _candidates = new Dictionary<string, Candidate>();
        private readonly Dictionary<string, Voter> _voters = new Dictionary<string, Voter>();
        private readonly Dictionary<string, Vote> _votes = new Dictionary<string, Vote>();

        public Task<Candidate> CreateCandidateAsync(Candidate candidate, CancellationToken cancellationToken)
        {
            _candidates.Add(candidate.Name, candidate);

            return Task.FromResult(candidate);
        }

        public Task<Vote> CreateVoteAsync(Vote vote, CancellationToken cancellationToken)
        {
            _votes.Add(vote.VoterName, vote);

            return Task.FromResult(vote);
        }

        public Task<Voter> CreateVoterAsync(Voter voter, CancellationToken cancellationToken)
        {
            _voters.Add(voter.Name, voter);

            return Task.FromResult(voter);
        }

        public Task<Candidate> GetCandidateByNameAsync(string name, CancellationToken cancellationToken)
        {
            _candidates.TryGetValue(name, out var candidate);

            return Task.FromResult(candidate);
        }

        public Task<Vote> GetVoteByVoterNameAsync(string voterName, CancellationToken cancellationToken)
        {
            _votes.TryGetValue(voterName, out var vote);

            return Task.FromResult(vote);
        }

        public Task<Voter> GetVoterByNameAsync(string name, CancellationToken cancellationToken)
        {
            _voters.TryGetValue(name, out var voter);

            return Task.FromResult(voter);
        }
    }
}
