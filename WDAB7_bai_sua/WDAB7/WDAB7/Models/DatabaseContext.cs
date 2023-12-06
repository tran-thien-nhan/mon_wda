using Microsoft.EntityFrameworkCore;

namespace WDAB7.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderItem>()
                .HasKey(ot=>new { ot.OrderId,ot.ProductId});
            modelBuilder.Entity<OrderItem>()
                .HasOne(ot => ot.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(ot => ot.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
              .HasOne(ot => ot.Product)
              .WithMany(p => p.OrderItems)
              .HasForeignKey(ot => ot.ProductId)
              .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
