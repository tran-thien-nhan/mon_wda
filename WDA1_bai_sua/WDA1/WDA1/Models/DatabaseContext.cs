using Microsoft.EntityFrameworkCore;

namespace WDA1.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AccountTb> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AccountTb>(e =>
            {
                e.ToTable("AccountTb"); //đặt lên tên bảng nếu muốn khác tên model
                e.Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn(100,1);
            });
            modelBuilder.Entity<AccountTb>().HasData(new AccountTb[]
            {
                new AccountTb{Id=1, Name="user", Password="123", Role = "User"},
                new AccountTb{Id=2, Name="admin", Password="123", Role = "Admin"}
            });
        }
    }
}
