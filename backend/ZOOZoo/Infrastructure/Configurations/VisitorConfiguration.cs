using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZOOZoo.Domain.Entities;

namespace ZOOZoo.Infrastructure.Configurations
{
    public class VisitorConfiguration : IEntityTypeConfiguration<Visitor>
    {
        public void Configure(EntityTypeBuilder<Visitor> builder)
        {
            builder.ToTable("Visitors");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.BirthDate)
                .IsRequired();
        }
    }
}
