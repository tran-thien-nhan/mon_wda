using Day4_Upload.Models;

namespace Day4_Upload.IRepository
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProduct(int id);
        Task<int> Create(Product product);
        Task<int> Update(Product product);
        Task<int> Delete(int id);
    }
}
