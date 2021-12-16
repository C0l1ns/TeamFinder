using TeamFinderDAL.Entities;
using TeamFinderDAL.Interfaces;

namespace TeamFinderDAL.Repositories
{
    public class BoardGameRepository:GenericRepository<BoardGame>,IBoardGameRepository
    {
        public BoardGameRepository(TeamFinderDbContext context) : base(context)
        {
        }
        
    }
}