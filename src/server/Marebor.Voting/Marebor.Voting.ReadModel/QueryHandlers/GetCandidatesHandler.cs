using Marebor.Voting.ReadModel.Models;
using Marebor.Voting.ReadModel.Queries;
using Marebor.Voting.ReadModel.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Marebor.Voting.ReadModel.QueryHandlers
{
    internal class GetCandidatesHandler : IRequestHandler<GetCandidates, IReadOnlyCollection<Candidate>>
    {
        private readonly ICandidateRepository _candidateRepository;

        public GetCandidatesHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public Task<IReadOnlyCollection<Candidate>> Handle(GetCandidates request, CancellationToken cancellationToken)
        {
            return _candidateRepository.GetCandidatesAsync(cancellationToken);
        }
    }
}
