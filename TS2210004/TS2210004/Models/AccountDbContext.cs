using Microsoft.EntityFrameworkCore;

namespace TS2210004.Models
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
                new Account { AccountNo = "A1", AccountName = "Nick", PinCode = "123", Balance = 100000, Role = true },
                new Account { AccountNo = "A2", AccountName = "Alex", PinCode = "123", Balance = 12000, Role = false },
                new Account { AccountNo = "A3", AccountName = "Andy", PinCode = "123", Balance = 3500, Role = false }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
