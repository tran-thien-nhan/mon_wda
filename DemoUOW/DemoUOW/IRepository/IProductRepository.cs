using DemoUOW.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoUOW.IRepository
{
    public interface IProductRepository
    {
        Task<int> AddProductAsync(Product product);
        Task<int> UpdateProductAsync(Product product);
        Task<int> DeleteProductAsync(int productId);
        Task<Product> GetProductsAsync(int productId);
        Task<IEnumerable<Product>> getAllProductAsync();
    }

}
