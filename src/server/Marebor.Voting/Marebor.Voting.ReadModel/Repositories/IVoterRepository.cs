using Marebor.Voting.ReadModel.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Marebor.Voting.ReadModel.Repositories
{
    public interface IVoterRepository
    {
        Task<Voter> CreateOrUpdateVoterAsync(Voter voter, CancellationToken cancellationToken);
        Task<Voter> GetVoterByNameAsync(string name, CancellationToken cancellationToken);
        Task<IReadOnlyCollection<Voter>> GetVotersAsync(CancellationToken cancellationToken);
    }
}
