using MediatR;

namespace Marebor.Voting.Core.Messaging.Events
{
    public class CandidateAdditionFailed : FailureEventBase, INotification
    {
    }
}
