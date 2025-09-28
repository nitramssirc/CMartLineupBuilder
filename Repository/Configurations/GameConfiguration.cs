using Domain.Aggregates;
using Domain.ValueTypes;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Game");

            // Primary key
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Id)
                .IsRequired();

            // Foreign key to Slate (no cascade delete)
            builder.Property(g => g.SlateID)
                .IsRequired();

            builder.HasOne<Slate>()
                .WithMany()
                .HasForeignKey(g => g.SlateID)
                .OnDelete(DeleteBehavior.Restrict);

            // Other properties
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
