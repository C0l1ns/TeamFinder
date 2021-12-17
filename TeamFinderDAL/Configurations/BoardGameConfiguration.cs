using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamFinderDAL.Entities;

namespace TeamFinder.Models.Configurations
{
    public class BoardGameConfiguration : IEntityTypeConfiguration<BoardGame>
    {
        public void Configure(EntityTypeBuilder<BoardGame> builder)
        {
            builder.HasKey(bg => bg.Id);

            builder.Property(bg => bg.Name)
                .IsRequired();

            builder.Property(bg => bg.Difficulty);


            builder.HasMany(bg => bg.Tags)
                .WithMany(t => t.BoardGames)
                .UsingEntity<Dictionary<string, object>>("BoardGame-Tag",
                    bg => bg.HasOne<Tag>().WithMany().HasForeignKey("TagId"),
                    bg => bg.HasOne<BoardGame>().WithMany().HasForeignKey("BGameId"),
                    bg => bg.ToTable("BoardGame-Tag"));
        }
    }
}