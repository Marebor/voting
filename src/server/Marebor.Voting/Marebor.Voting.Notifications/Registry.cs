using Marebor.Voting.Notifications.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace Marebor.Voting.Notifications
{
    public static class Registry
    {
        public static IServiceCollection AddNotificationsServices(this IServiceCollection services)
        {
            services.AddSignalR();

            return services
                .AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Registry).Assembly))
                .AddTransient<INotificationSender, NotificationSender>();
        }
    }
}
