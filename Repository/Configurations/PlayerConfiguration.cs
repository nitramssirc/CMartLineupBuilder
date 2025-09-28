using Domain.Aggregates;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Players");

            // Primary key
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .IsRequired();

            // Foreign key to Slate
            builder.Property(p => p.SlateID)
                .IsRequired();

            builder.HasOne<Slate>()
                .WithMany()
                .HasForeignKey(p => p.SlateID)
                .OnDelete(DeleteBehavior.Restrict);

            // Foreign key to Game
            builder.Property(p => p.GameID)
                .IsRequired();

            builder.HasOne<Game>()
                .WithMany()
                .HasForeignKey(p => p.GameID)
                .OnDelete(DeleteBehavior.Restrict);

            // Name and Team
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Team)
                .IsRequired();

            // Unique constraint on SlateID, Name, Team
            builder.HasIndex(p => new { p.SlateID, p.Name, p.Team }).IsUnique();

            // Salary as value object
            builder.OwnsOne(p => p.Salary, salaryBuilder =>
            {
                salaryBuilder.Property(s => s.SalaryAmount).IsRequired();
                salaryBuilder.Property(s => s.DFSSiteID).IsRequired().HasMaxLength(50);
                salaryBuilder.Property(s => s.Positions)
                    .HasConversion(
                        v => string.Join(",", v.Select(pos => pos.ToString())),
                        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                              .Select(s => Enum.Parse<Common.Enums.PlayerPosition>(s))
                              .ToArray()
                    )
                    .IsRequired();
            });

            // Projections as value object collection
            builder.OwnsMany(p => p.Projections, projectionBuilder =>
            {
                projectionBuilder.WithOwner().HasForeignKey("PlayerId");
                projectionBuilder.Property(p => p.ProjectionSource)
                    .HasConversion<string>()
                    .IsRequired();

                // Enforce one projection per source per player
                projectionBuilder.HasIndex("PlayerId", nameof(Domain.ValueTypes.Projection.ProjectionSource)).IsUnique();

                // ProjectionData as value object collection
                projectionBuilder.OwnsMany(p => p.Data, dataBuilder =>
                {
                    dataBuilder.WithOwner().HasForeignKey("ProjectionId");
                    dataBuilder.Property(d => d.StatCategory).IsRequired();
                    dataBuilder.Property(d => d.Value).IsRequired().HasColumnType("decimal(18,2)");
                    dataBuilder.Property<int>("Id");
                    dataBuilder.HasKey("Id");
                });
            });
        }
    }
}