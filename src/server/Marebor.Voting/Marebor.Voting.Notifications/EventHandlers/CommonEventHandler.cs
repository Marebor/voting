using Marebor.Voting.Core.Messaging.Events;
using Marebor.Voting.Notifications.DTOs;
using Marebor.Voting.Notifications.Messaging;
using MediatR;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Marebor.Voting.Notifications.EventHandlers
{
    internal class CommonEventHandler :
        INotificationHandler<CandidateAdded>,
        INotificationHandler<CandidateAdditionFailed>,
        INotificationHandler<VoterAdded>,
        INotificationHandler<VoterAdditionFailed>,
        INotificationHandler<VoteAdded>,
        INotificationHandler<VoteFailed>
    {
        private readonly INotificationSender _notificationSender;

        public CommonEventHandler(INotificationSender notificationSender)
        {
            _notificationSender = notificationSender;
        }

        public Task Handle(CandidateAdded notification, CancellationToken cancellationToken)
        {
            return SendNotifications(notification, cancellationToken);
        }
        public Task Handle(CandidateAdditionFailed notification, CancellationToken cancellationToken)
        {
            return SendNotifications(notification, cancellationToken);
        }
        public Task Handle(VoterAdded notification, CancellationToken cancellationToken)
        {
            return SendNotifications(notification, cancellationToken);
        }
        public Task Handle(VoterAdditionFailed notification, CancellationToken cancellationToken)
        {
            return SendNotifications(notification, cancellationToken);
        }
        public Task Handle(VoteAdded notification, CancellationToken cancellationToken)
        {
            return SendNotifications(notification, cancellationToken);
        }
        public Task Handle(VoteFailed notification, CancellationToken cancellationToken)
        {
            return SendNotifications(notification, cancellationToken);
        }

        private async Task SendNotifications(EventBase notification, CancellationToken cancellationToken)
        {
            await _notificationSender.SendNotificationAsync(
                notification.CommandId.ToString(), 
                new CommandResult { Succeeded = true });
            await _notificationSender.SendNotificationAsync(
                notification.GetType().Name, notification);
        }

        private async Task SendNotifications(FailureEventBase notification, CancellationToken cancellationToken)
        {
            await _notificationSender.SendNotificationAsync(
                notification.CommandId.ToString(),
                new CommandResult { Succeeded = false, Error = notification.Error });
        }
    }
}
