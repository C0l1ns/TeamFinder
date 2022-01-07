using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TeamFinderDAL.Entities;

namespace TeamFinder.Models.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            // builder.Property(u => u.Username)
            //     .IsRequired();
            
            builder.Property(u => u.DisplayUsername);

            builder.Property(u => u.About)
                .HasMaxLength(255);

            builder.Property(u => u.Password)
                .IsRequired();

            builder.Property(u => u.Email)
                .IsRequired();

            builder.Property(u => u.Rating)
                .IsRequired();

            
            builder.HasMany(u => u.ConnectedLobbies)
                .WithMany(l => l.ConnectedUsers)
                .UsingEntity<Dictionary<string, object>>("User-Lobby",
                    u => u.HasOne<Lobby>().WithMany().HasForeignKey("LobbyId"),
                    u => u.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    u => u.ToTable("User-Lobby"));

            builder.HasMany(u => u.FavoriteGames)
                .WithMany(bg => bg.FavoredByUsers)
                .UsingEntity<Dictionary<string, object>>("User-BoardGame",
                    u => u.HasOne<BoardGame>().WithMany().HasForeignKey("BGameId"),
                    u => u.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    u => u.ToTable("User-BoardGame"));

            builder.HasMany(u => u.Friends)
                .WithMany(f => f.FriendOf)
                .UsingEntity<Dictionary<string, object>>("User-Friend",
                u => u.HasOne<User>().WithMany().HasForeignKey("UserId"),
                u => u.HasOne<User>().WithMany().HasForeignKey("FriendId"),
                u => u.ToTable("User-Friend"));
        } 
    }
}