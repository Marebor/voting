using Marebor.Voting.ReadModel.Models;
using Marebor.Voting.ReadModel.Queries;
using Marebor.Voting.ReadModel.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Marebor.Voting.ReadModel.QueryHandlers
{
    internal class GetVotersHandler : IRequestHandler<GetVoters, IReadOnlyCollection<Voter>>
    {
        private readonly IVoterRepository _voterRepository;

        public GetVotersHandler(IVoterRepository voterRepository)
        {
            _voterRepository = voterRepository;
        }

        public Task<IReadOnlyCollection<Voter>> Handle(GetVoters request, CancellationToken cancellationToken)
        {
            return _voterRepository.GetVotersAsync(cancellationToken);
        }
    }
}
