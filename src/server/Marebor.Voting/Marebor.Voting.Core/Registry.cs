using Microsoft.Extensions.DependencyInjection;

namespace Marebor.Voting.Core
{
    public static class Registry
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            return services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Registry).Assembly));
        }
    }
}
