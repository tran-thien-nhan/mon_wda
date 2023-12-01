using de_1_codeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace de_1_codeFirst.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        //trường hợp muốn đổi tên table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            base.OnModelCreating(modelBuilder);
        }
    }
}
