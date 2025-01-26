using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;
using Domain.ValueTypes;

namespace Infrastructure.Persistence.Configurations
{
    public class ProjectionConfiguration : IEntityTypeConfiguration<Projection>
    {
        public void Configure(EntityTypeBuilder<Projection> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasConversion(
                    id => id.Id,
                    value => new ProjectionID(value))
                .IsRequired();

            builder.Property(p => p.SlateID)
                .HasConversion(
                    id => id.Id,
                    value => new SlateID(value))
                .IsRequired();

            builder.HasOne<Slate>()
                .WithMany(s => s.Projections)
                .HasForeignKey(p => p.SlateID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.ProjectionSource)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(p => p.PlayerName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Team)
                .IsRequired();

            builder.OwnsMany(p => p.Data, a =>
            {
                a.WithOwner().HasForeignKey("ProjectionId");
                a.Property<int>("Id");
                a.HasKey("Id");
                a.Property(p => p.StatCategory).IsRequired();
                a.Property(p => p.Value).IsRequired().HasColumnType("decimal(18,2)");
            });

        }
    }
}
