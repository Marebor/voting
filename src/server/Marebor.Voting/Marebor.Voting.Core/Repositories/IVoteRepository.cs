using Marebor.Voting.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Marebor.Voting.Core.Repositories
{
    public interface IVoteRepository
    {
        Task<Vote> GetVoteByVoterNameAsync(string voterName, CancellationToken cancellationToken);
        Task<Vote> CreateVoteAsync(Vote vote, CancellationToken cancellationToken);
    }
}
