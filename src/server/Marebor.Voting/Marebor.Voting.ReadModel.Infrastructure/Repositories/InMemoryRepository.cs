using Marebor.Voting.ReadModel.Models;
using Marebor.Voting.ReadModel.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Marebor.Voting.ReadModel.Infrastructure.Repositories
{
    // for simplicity - repo without validations and multi-threading
    internal class InMemoryRepository : ICandidateRepository, IVoterRepository
    {
        private readonly Dictionary<string, Candidate> _candidates = new Dictionary<string, Candidate>();
        private readonly Dictionary<string, Voter> _voters = new Dictionary<string, Voter>();

        public Task<Candidate> CreateOrUpdateCandidateAsync(Candidate candidate, CancellationToken cancellationToken)
        {
            _candidates.TryAdd(candidate.Name, candidate);

            return Task.FromResult(candidate);
        }

        public Task<Voter> CreateOrUpdateVoterAsync(Voter voter, CancellationToken cancellationToken)
        {
            _voters.TryAdd(voter.Name, voter);

            return Task.FromResult(voter);
        }

        public Task<Candidate> GetCandidateByNameAsync(string name, CancellationToken cancellationToken)
        {
            _candidates.TryGetValue(name, out var candidate);

            return Task.FromResult(candidate);
        }

        public Task<IReadOnlyCollection<Candidate>> GetCandidatesAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult((IReadOnlyCollection<Candidate>)_candidates.Values.ToArray());
        }

        public Task<Voter> GetVoterByNameAsync(string name, CancellationToken cancellationToken)
        {
            _voters.TryGetValue(name, out var voter);

            return Task.FromResult(voter);
        }

        public Task<IReadOnlyCollection<Voter>> GetVotersAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult((IReadOnlyCollection<Voter>)_voters.Values.ToArray());
        }
    }
}
