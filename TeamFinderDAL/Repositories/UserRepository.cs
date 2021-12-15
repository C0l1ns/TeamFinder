using Microsoft.EntityFrameworkCore;
using TeamFinderDAL.Interfaces;
using TeamFinderDAL.Entities;
namespace TeamFinderDAL.Repositories
{
    public class UserRepository:GenericRepository<User>
    {
        public UserRepository(TeamFinderDbContext teamFinderDbContext) : base(teamFinderDbContext)
        {
        }
        
    }
}