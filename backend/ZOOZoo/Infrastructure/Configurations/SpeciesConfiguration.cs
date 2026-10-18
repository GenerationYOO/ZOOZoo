using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZOOZoo.Domain.Entities;

namespace ZOOZoo.Infrastructure.Configurations
{
    public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
    {
        public void Configure(EntityTypeBuilder<Species> builder)
        {
            builder.ToTable("Species");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(s => s.Animals)
                .WithOne(a => a.Species)
                .HasForeignKey(a => a.SpeciesId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
