using Domain.Entities;
using Domain.ValueTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class SalaryConfiguration : IEntityTypeConfiguration<Salary>
    {
        public void Configure(EntityTypeBuilder<Salary> builder)
        {
            builder.ToTable("Salaries");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .HasConversion(
                    id => id.Id,
                    value => new SalaryID(value))
                .IsRequired();

            builder.Property(s => s.SlateID)
                .HasConversion(
                    id => id.Id,
                    value => new SlateID(value))
                .IsRequired();

            builder.Property(s => s.PlayerName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.SalaryAmount)
                .IsRequired();

            builder.Property(s => s.DFSSiteID)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne<Slate>()
                .WithMany(s => s.Salaries)
                .HasForeignKey(s => s.SlateID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
