using Microsoft.EntityFrameworkCore;

namespace hw_wda1.Models
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AccountTb> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountTb>().HasData(
                new AccountTb { Id = 1, Username = "admin", Password = "123", Role = false },
                new AccountTb { Id = 2, Username = "user", Password = "123", Role = true }
            );
        }
    }
}
