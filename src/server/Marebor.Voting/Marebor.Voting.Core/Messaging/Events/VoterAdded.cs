using MediatR;

namespace Marebor.Voting.Core.Messaging.Events
{
    public class VoterAdded : EventBase, INotification
    {
        public string Name { get; set; }
    }
}
