using Microsoft.EntityFrameworkCore;

namespace bt_order.Models
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }    
        public DbSet<OrderDetail> Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                .HasOne(o => o.Order)
                .WithMany(d => d.Details)
                .HasForeignKey(o => o.OrderId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
