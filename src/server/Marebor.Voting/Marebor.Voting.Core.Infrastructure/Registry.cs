using Marebor.Voting.Core.Infrastructure.Repositories;
using Marebor.Voting.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Marebor.Voting.Core.Infrastructure
{
    public static class Registry
    {
        public static IServiceCollection AddCoreInfrastructureServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<ICandidateRepository, InMemoryRepository>()
                .AddSingleton<IVoterRepository, InMemoryRepository>()
                .AddSingleton<IVoteRepository, InMemoryRepository>();
        }
    }
}
