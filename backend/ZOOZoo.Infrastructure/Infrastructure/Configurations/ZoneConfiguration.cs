using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZOOZoo.Domain.Entities;

namespace ZOOZoo.Infrastructure.Configurations
{
    public class ZoneConfiguration : IEntityTypeConfiguration<Zone>
    {
        public void Configure(EntityTypeBuilder<Zone> builder)
        {
            builder.ToTable("Zones");

            builder.HasKey(z => z.Id);

            builder.Property(z => z.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(z => z.AccessPolicyCode)
                .IsRequired();

            builder.Property(z => z.InteractionPolicyCode)
                .IsRequired();

            builder.Property(z => z.RequiredAccessLevel)
                .IsRequired();

            builder.Property(z => z.MinVisitorAge)
                .IsRequired();

            builder.Property(z => z.OpenFrom)
                .IsRequired();

            builder.Property(z => z.OpenTo)
                .IsRequired();

            builder.Property(z => z.IsAvailable)
                .IsRequired();

            builder.HasMany(z => z.Animals)
                .WithOne(a => a.Zone)
                .HasForeignKey(a => a.ZoneId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
