using Activities.Entities;
using Activities.Interactors;
using Activities.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Activities.DependencyInversion
{
    public static class DependencyContainer
    {
        public static IServiceCollection BackkServices(this IServiceCollection serviceCollection,
            ConnectionStringOptions options)
        {
            serviceCollection.AddRepositories(options);
            serviceCollection.AddInteractor();
            return serviceCollection;
        }
    }
}
