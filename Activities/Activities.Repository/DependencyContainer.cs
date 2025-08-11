using Activities.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Activities.Repository
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services,
            ConnectionStringOptions options)
        {
            return services;
        }
    }
}
