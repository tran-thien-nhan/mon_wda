using de_1_codeFirst.Models;

namespace de_1_codeFirst.IRepository
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);

        Task<Product> GetProductByName(string name);
        Task<int> Create(Product product);
        Task<int> Update(Product product);
        Task<int> Delete(int id);
    }
}
