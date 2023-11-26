using Marebor.Voting.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Marebor.Voting.Core.Repositories
{
    public interface IVoterRepository
    {
        Task<Voter> GetVoterByNameAsync(string name, CancellationToken cancellationToken);
        Task<Voter> CreateVoterAsync(Voter voter, CancellationToken cancellationToken);
    }
}
