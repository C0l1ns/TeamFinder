using Microsoft.Extensions.DependencyInjection;
using TeamFinderBL.Interfaces;
using TeamFinderBL.Services;
using TeamFinderDAL.Interfaces;

namespace TeamFinderPL.Configurations
{
    public static class ServiceProviderExtension
    {
        public static void AddServiceProvider(this IServiceCollection services)
        {
            services.AddTransient<ILobbyService, LobbyService>();
            services.AddTransient<IBoardGameService, BoardGameService>();
        }
    }
}