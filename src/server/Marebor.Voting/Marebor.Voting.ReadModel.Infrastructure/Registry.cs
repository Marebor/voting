using Marebor.Voting.ReadModel.Infrastructure.Repositories;
using Marebor.Voting.ReadModel.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Marebor.Voting.ReadModel.Infrastructure
{
    public static class Registry
    {
        public static IServiceCollection AddReadModelInfrastructureServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<ICandidateRepository, InMemoryRepository>()
                .AddSingleton<IVoterRepository, InMemoryRepository>();
        }
    }
}
