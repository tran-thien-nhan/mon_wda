using hw_wda1.IRepository;
using hw_wda1.Models;
using Microsoft.EntityFrameworkCore;

namespace hw_wda1.Repository
{
    public class AccountRepo : IAccountRepo
    {
        private readonly AccountDbContext db;

        public AccountRepo(AccountDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(AccountTb account)
        {
            db.Accounts.Add(account);
            try
            {
                return await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> Delete(int id)
        {
            var acc = await db.Accounts.SingleOrDefaultAsync(a => a.Id == id);
            if (acc != null)
            {
                db.Remove(acc);
                return await db.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }

        public async Task<AccountTb> Get(int id)
        {
            var acc = await db.Accounts.SingleOrDefaultAsync(a => a.Id == id);
            return acc;
        }

        public async Task<IEnumerable<AccountTb>> getAll()
        {
            var accList = await db.Accounts.ToListAsync();
            return accList;
        }
    }
}
