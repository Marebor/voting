using Marebor.Voting.ReadModel.Models;
using MediatR;
using System.Collections.Generic;

namespace Marebor.Voting.ReadModel.Queries
{
    public class GetVoters : IRequest<IReadOnlyCollection<Voter>>
    {
    }
}
