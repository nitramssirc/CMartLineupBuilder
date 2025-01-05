using Domain.Entities;
using Domain.ValueTypes;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class SlateConfiguration : IEntityTypeConfiguration<Slate>
    {
        public void Configure(EntityTypeBuilder<Slate> builder)
        {
            builder.ToTable("Slates");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .HasConversion(
                    id => id.Id, 
                    value => new SlateID(value))
                .IsRequired();


            builder.Property(s => s.Date)
                .IsRequired();

            builder.Property(s => s.Sport)
                .HasConversion<string>() 
                .IsRequired();

            builder.Property(s => s.GameType)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(s => s.DFSSite)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(s => s.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
