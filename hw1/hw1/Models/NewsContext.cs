using Microsoft.EntityFrameworkCore;

namespace hw1.Models
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<tbAdmin> Admins { get; set; }
        public DbSet<tbNews> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbAdmin>().HasData(
                new tbAdmin { UserName = "Admin", Password = "123" }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
