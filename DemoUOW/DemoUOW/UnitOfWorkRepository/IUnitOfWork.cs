using DemoUOW.IRepository;
using DemoUOW.Models;

namespace DemoUOW.UnitOfWorkRepository
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        Task<IEnumerable<Product>> GetProductsAbovePriceAsync(int threshold);

        Task<int> Save();
    }

}
