using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TeamFinderDAL.Entities;
using TeamFinderDAL.Interfaces;

namespace TeamFinderDAL.Repositories
{
    public class LobbyRepository : GenericRepository<Lobby>, ILobbyRepository
    {
        private readonly TeamFinderDbContext _context;
        public LobbyRepository(TeamFinderDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<Lobby> GetById(int id)
        {
            return _context.Lobbies.Include(x => x.ConnectedUsers).SingleOrDefaultAsync(x => x.Id == id);
        }



    }
}  

    
