using Microsoft.EntityFrameworkCore;
using TeamFinder.Models;
using TeamFinder.Models.EntityConfigurations;
using TeamFinderDAL.Models.Entities;

namespace TeamFinder.Data
{
    public class TeamFinderDbContext : DbContext
    {
        public TeamFinderDbContext(DbContextOptions<TeamFinderDbContext> options) 
            : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Lobby> Lobbies { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BoardGameConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new LobbyConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}