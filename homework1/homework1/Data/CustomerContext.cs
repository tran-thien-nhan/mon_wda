using homework1.Models;
using Microsoft.EntityFrameworkCore;

namespace homework1.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }

        //trường hợp muốn đổi tên table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            base.OnModelCreating(modelBuilder);
        }
    }
}
