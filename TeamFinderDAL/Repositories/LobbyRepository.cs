using TeamFinderDAL.Entities;

namespace TeamFinderDAL.Repositories
{
    public class LobbyRepository:GenericRepository<Lobby>
    {
        public LobbyRepository(TeamFinderDbContext teamFinderDbContext) : base(teamFinderDbContext)
        {
        }
    }
}