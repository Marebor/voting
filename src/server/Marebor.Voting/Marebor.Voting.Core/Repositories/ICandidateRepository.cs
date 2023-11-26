using Marebor.Voting.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Marebor.Voting.Core.Repositories
{
    public interface ICandidateRepository
    {
        Task<Candidate> GetCandidateByNameAsync(string name, CancellationToken cancellationToken);
        Task<Candidate> CreateCandidateAsync(Candidate candidate, CancellationToken cancellationToken);
    }
}
