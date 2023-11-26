using Marebor.Voting.ReadModel.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Marebor.Voting.ReadModel.Repositories
{
    public interface ICandidateRepository
    {
        Task<Candidate> CreateOrUpdateCandidateAsync(Candidate candidate, CancellationToken cancellationToken);
        Task<Candidate> GetCandidateByNameAsync(string name, CancellationToken cancellationToken);
        Task<IReadOnlyCollection<Candidate>> GetCandidatesAsync(CancellationToken cancellationToken);
    }
}
