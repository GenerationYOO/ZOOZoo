using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZOOZoo.Domain.Entities;

namespace ZOOZoo.Infrastructure.Configurations
{
    public class TicketTypeConfiguration : IEntityTypeConfiguration<TicketType>
    {
        public void Configure(EntityTypeBuilder<TicketType> builder)
        {
            builder.ToTable("TicketTypes");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.BasePrice)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(t => t.AccessLevel)
                .IsRequired();

            builder.Property(t => t.PricingStrategyCode)
                .IsRequired();
        }
    }
}
