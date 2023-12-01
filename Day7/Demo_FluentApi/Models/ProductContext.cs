using Microsoft.EntityFrameworkCore;
using Demo_FluentApi.Models;

namespace Demo_FluentApi.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(c =>
            {
                c.HasKey(c => c.Id);
                c.Property(c => c.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category { Id = 1,Name="Food"},
                new Category { Id = 2,Name="Book"},
            });

            modelBuilder.Entity<Product>(p =>
            {
                p.HasKey(p => p.Id);
                p.HasOne(p => p.Category).WithMany(p => p.Products).HasForeignKey(p => p.Id);
            });

            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new Product { Id = 1, Name="Food1",CategoryId=1},
                new Product { Id = 2, Name="Book1",CategoryId=2},
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Demo_FluentApi.Models.Category>? Category { get; set; }

        public DbSet<Demo_FluentApi.Models.Product>? Product { get; set; }
    }
}
