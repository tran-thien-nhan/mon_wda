using Microsoft.EntityFrameworkCore;

namespace WDA3.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderDetail>(e =>
            {
                //khai bao khoa chinh
                e.HasKey(o =>  new {o.OrderId, o.ProductName});
                //khai bao khoa ngoai
                e.HasOne(e => e.Order).WithMany(o => o.OrderDetails)
                    .HasForeignKey(o => o.OrderId);
            });

            modelBuilder.Entity<Order>().HasData( new Order[]
            {
                new Order {Id = "O001", Address="Hcm", Name="Van A", Phone="113"},
                new Order {Id = "O002", Address="HN", Name="Van B", Phone="114"},
                new Order {Id = "O003", Address="DN", Name="Van C", Phone="115"}
            });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail[] {
                new OrderDetail {OrderId="O001", ProductName="Pepsi", Price=3, Quantity= 10},
                new OrderDetail {OrderId="O001", ProductName="Coce", Price=3, Quantity= 5},
                new OrderDetail {OrderId="O002", ProductName="Bun bo", Price=10, Quantity= 1}
            });
        }
    }
}
