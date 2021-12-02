using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TeamFinder.Models.EntityConfigurations
{
    public class LobbyConfiguration : IEntityTypeConfiguration<Lobby>
    {
        public void Configure(EntityTypeBuilder<Lobby> builder)
        {
            builder.HasKey(l => l.LobbyId);

            builder.Property(l => l.LobbyName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(l => l.About)
                .HasMaxLength(255);
            
            builder.Property(l => l.GameDate)
                .IsRequired();
            
            builder.Property(l => l.GameLocation)
                .HasMaxLength(255);
            

            builder.HasMany(l => l.ConnectedUsers)
                .WithMany(u => u.ConnectedLobbies);

            builder.HasOne(l => l.Host)
                .WithMany()
                .HasForeignKey(l => l.HostId);

            builder.HasOne(l => l.HostedGame)
                .WithMany()
                .HasForeignKey(l => l.HostedGameId);

            builder.HasMany(l => l.Messages)
                .WithOne(m => m.Lobby);

        }
    }
}