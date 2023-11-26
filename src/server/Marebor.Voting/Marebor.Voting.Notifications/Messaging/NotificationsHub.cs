using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace Marebor.Voting.Notifications.Messaging
{
    public class NotificationsHub : Hub<INotificationSender>
    {
        public async Task Subscribe(string subscriptionName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, subscriptionName);
        }

        public async Task Unsubscribe(string subscriptionName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, subscriptionName);
        }

        public Task SendNotificationAsync(string subscriptionName, string notification)
        {
            INotificationSender sender = TryGetSender(subscriptionName);

            return sender != null ? sender.SendNotificationAsync(subscriptionName, notification) : Task.CompletedTask;
        }

        private INotificationSender TryGetSender(string subscriptionName)
        {
            try
            {
                return Clients.Group(subscriptionName);
            }
            catch
            {
                return null;
            }
        }
    }
}
