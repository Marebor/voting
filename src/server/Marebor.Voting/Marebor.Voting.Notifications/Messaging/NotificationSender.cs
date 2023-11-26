using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Marebor.Voting.Notifications.Messaging
{
    public class NotificationSender : INotificationSender
    {
        private IHubContext<NotificationsHub, INotificationSender> _hubContext;

        public NotificationSender(IHubContext<NotificationsHub, INotificationSender> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task SendNotificationAsync(string subscriptionName, object notification)
        {
            return _hubContext.Clients.Group(subscriptionName).SendNotificationAsync(subscriptionName, notification);
        }
    }
}
