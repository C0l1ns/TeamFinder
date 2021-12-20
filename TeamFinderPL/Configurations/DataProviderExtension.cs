using Microsoft.Extensions.DependencyInjection;
using TeamFinderDAL.Entities;
using TeamFinderDAL.Interfaces;
using TeamFinderDAL.Repositories;

namespace TeamFinderPL.Configurations
{
    public static class DataProviderExtension
    {
        // тут прописується зв'язування репозиторіїв
        public static void AddDataProvider(this IServiceCollection services)
        {
            services.AddTransient<IBoardGameRepository, BoardGameRepository>();
            services.AddTransient<ILobbyRepository, LobbyRepository>();
        }
    }
}