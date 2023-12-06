using hw_wda1.Models;

namespace hw_wda1.IRepository
{
    public interface IAccountRepo
    {
        Task<IEnumerable<AccountTb>> getAll();

        Task<AccountTb> Get(int id);

        Task<int> Delete(int id);

        Task<int> Create(AccountTb account);
    }
}
