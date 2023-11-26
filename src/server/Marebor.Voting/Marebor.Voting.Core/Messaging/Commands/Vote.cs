using MediatR;

namespace Marebor.Voting.Core.Messaging.Commands
{
    public class Vote : CommandBase, IRequest
    {
        public string VoterName { get; set; }
        public string CandidateName { get; set; }
    }
}
