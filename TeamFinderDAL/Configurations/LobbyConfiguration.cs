using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamFinderDAL.Entities;

namespace TeamFinder.Models.Configurations
{
    public class LobbyConfiguration : IEntityTypeConfiguration<Lobby>
    {
        public void Configure(EntityTypeBuilder<Lobby> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.About)
                .HasMaxLength(255);
            
            builder.Property(l => l.GameDate)
                .IsRequired();
            
            builder.Property(l => l.GameLocation)
                .HasMaxLength(255);

            builder.Property(l => l.MinNumberOfPlayers);

            builder.Property(l => l.MaxNumberOfPlayers);


            builder.HasMany(l => l.ConnectedUsers)
                .WithMany(u => u.ConnectedLobbies);

            builder.HasOne(l => l.Host)
                .WithMany()
                .HasForeignKey(l => l.HostId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(l => l.HostedGame)
                .WithMany()
                .HasForeignKey(l => l.HostedGameId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(l => l.Messages)
                .WithOne(m => m.Lobby)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}