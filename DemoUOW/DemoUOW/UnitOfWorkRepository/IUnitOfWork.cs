using DemoUOW.Models;

namespace DemoUOW.UnitOfWorkRepository
{
    public interface IUnitOfWork
    {
        Task<int> AddProductAsync(Product product);
        Task<int> UpdateProductAsync(Product product);
        Task<int> DeleteProductAsync(int productId);
        Task<Product> GetProductsAsync(int productId);
        Task<IEnumerable<Product>> getAllProductAsync();
    }

}
