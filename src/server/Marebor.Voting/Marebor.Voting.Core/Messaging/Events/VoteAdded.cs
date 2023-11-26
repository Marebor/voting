using MediatR;

namespace Marebor.Voting.Core.Messaging.Events
{
    public class VoteAdded : EventBase, INotification
    {
        public string VoterName { get; set; }
        public string CandidateName { get; set; }
    }
}
