using System.Threading;
using System.Threading.Tasks;

namespace Marebor.Voting.Notifications.Messaging
{
    public interface INotificationSender
    {
        Task SendNotificationAsync(string subscriptionName, object notification);
    }
}
