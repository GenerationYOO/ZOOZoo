using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZOOZoo.Domain.Entities;

namespace ZOOZoo.Infrastructure.Configurations
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.ToTable("Animals");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.HealthStatus)
                .IsRequired();

            builder.Property(a => a.DietType)
                .IsRequired();

            builder.HasIndex(a => a.SpeciesId);
            builder.HasIndex(a => a.ZoneId);

            builder.HasOne(a => a.Species)
                .WithMany(s => s.Animals)
                .HasForeignKey(a => a.SpeciesId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Zone)
                .WithMany(z => z.Animals)
                .HasForeignKey(a => a.ZoneId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ComplexProperty(a => a.FeedingWindow, window =>
            {
                window.Property(w => w.Start)
                    .HasColumnName("FeedingFrom")
                    .IsRequired();

                window.Property(w => w.End)
                    .HasColumnName("FeedingTo")
                    .IsRequired();
            });
        }
    }
}
