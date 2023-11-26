using Marebor.Voting.ReadModel.Models;
using MediatR;
using System.Collections.Generic;

namespace Marebor.Voting.ReadModel.Queries
{
    public class GetCandidates : IRequest<IReadOnlyCollection<Candidate>>
    {
    }
}
