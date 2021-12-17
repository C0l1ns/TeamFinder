using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamFinderDAL.Entities;

namespace TeamFinder.Models.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Text)
                .IsRequired()
                .HasMaxLength(255);
            
            builder.Property(m => m.Date)
                .IsRequired();


            builder.HasOne(m => m.Lobby)
                .WithMany(g => g.Messages)
                .HasForeignKey(l => l.LobbyId);

            builder.HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(l => l.SenderId);
        }
    }
}