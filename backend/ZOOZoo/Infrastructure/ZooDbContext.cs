using Microsoft.EntityFrameworkCore;
using ZOOZoo.Domain.Entities;

namespace ZOOZoo.Infrastructure
{
    public class ZooDbContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public ZooDbContext(DbContextOptions<ZooDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ZooDbContext).Assembly);
        }
    }
}
