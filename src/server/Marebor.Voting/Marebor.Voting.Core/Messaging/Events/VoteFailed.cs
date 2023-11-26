using MediatR;

namespace Marebor.Voting.Core.Messaging.Events
{
    public class VoteFailed : FailureEventBase, INotification
    {
    }
}
