using Microsoft.Extensions.DependencyInjection;

namespace Marebor.Voting.ReadModel
{
    public static class Registry
    {
        public static IServiceCollection AddReadModelServices(this IServiceCollection services)
        {
            return services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Registry).Assembly));
        }
    }
}
