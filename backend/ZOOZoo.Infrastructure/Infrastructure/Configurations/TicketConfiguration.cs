using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZOOZoo.Domain.Entities;

namespace ZOOZoo.Infrastructure.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Tickets");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.ValidFrom)
                .IsRequired();

            builder.Property(t => t.ValidTo)
                .IsRequired();

            builder.Property(t => t.Price)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(t => t.CreatedAt)
                .IsRequired();

            builder.HasIndex(t => t.VisitorId);
            builder.HasIndex(t => t.TicketTypeId);

            builder.HasOne(t => t.Visitor)
                .WithMany()
                .HasForeignKey(t => t.VisitorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.TicketType)
                .WithMany()
                .HasForeignKey(t => t.TicketTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
