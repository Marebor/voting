using MediatR;

namespace Marebor.Voting.Core.Messaging.Events
{
    public class VoterAdditionFailed : FailureEventBase, INotification
    {
    }
}
