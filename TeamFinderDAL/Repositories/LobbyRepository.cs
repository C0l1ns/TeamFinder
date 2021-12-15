using TeamFinderDAL.Entities;
using TeamFinderDAL.Interfaces;

namespace TeamFinderDAL.Repositories
{
    public class LobbyRepository:GenericRepository<Lobby>,ILobbyRepository
    {
        public LobbyRepository(TeamFinderDbContext context) : base(context)
        {
        }
    }
}