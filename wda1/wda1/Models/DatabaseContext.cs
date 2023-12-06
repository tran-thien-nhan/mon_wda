using Microsoft.EntityFrameworkCore;

namespace wda1.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AccountTb> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountTb>(e =>
            {
                e.ToTable("AccountTb"); //sửa tên bảng
                e.Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn(100, 1);
            });
            modelBuilder.Entity<AccountTb>().HasData(
                new AccountTb { Id = 1, Username = "admin", Password = "123", Role = "Admin" },
                new AccountTb { Id = 2, Username = "user", Password = "123", Role = "User" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
