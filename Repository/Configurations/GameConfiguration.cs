using Domain.Entities;
using Domain.ValueTypes;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            // Configure the primary key
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Id)
                   .HasConversion(
                       id => id.Id,
                       value => new GameID(value))
                   .IsRequired();

            // Configure properties
            builder.Property(g => g.SlateID)
                    .HasConversion(
                        id => id.Id,
                        value => new SlateID(value))
                    .IsRequired();

            builder.HasOne<Slate>()
                .WithMany(s => s.Games)
                .HasForeignKey(g => g.SlateID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(g => g.HomeTeam)
                   .IsRequired();

            builder.Property(g => g.AwayTeam)
                   .IsRequired();

            builder.Property(g => g.StartTime)
                   .IsRequired();

            builder.Property(g => g.HomePoints)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(g => g.AwayPoints)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

        }
    }
}
