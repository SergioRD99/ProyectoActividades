using Microsoft.Extensions.DependencyInjection;

namespace Activities.Interactors
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddInteractor(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}
