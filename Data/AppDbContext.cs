using Microsoft.EntityFrameworkCore;
using TeamFinder.Models;

namespace TeamFinder.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; } 
    }
}