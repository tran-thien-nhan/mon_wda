using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace wda2.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(p => p.Position)
                .WithMany(e => e.Employee)
                .HasForeignKey(p => p.PositionId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
