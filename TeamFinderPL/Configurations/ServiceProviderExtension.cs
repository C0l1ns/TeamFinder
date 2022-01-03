using Microsoft.Extensions.DependencyInjection;

namespace TeamFinderPL.Configurations
{
    public static class ServiceProviderExtension
    {
        public static void AddServiceProvider(this IServiceCollection services)
        {
            services.AddTransient<ILobbyService,LobbyService>()
        }
    }
}