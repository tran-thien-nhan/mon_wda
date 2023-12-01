using DemoUOW.IRepository;
using DemoUOW.Models;
using DemoUOW.UnitOfWorkRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace DemoUOW.UnitOfWork
{
    public class UnitOfWorkRepo : IUnitOfWork
    {
        private IProductRepository repo;

        public UnitOfWorkRepo(IProductRepository repo)
        {
            this.repo = repo;
        }

        public async Task<int> AddProductAsync(Product product)
        {
            return await repo.AddProductAsync(product);
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            return await repo.UpdateProductAsync(product);
        }

        public async Task<int> DeleteProductAsync(int productId)
        {
            return await repo.DeleteProductAsync(productId);
        }

        public async Task<Product> GetProductsAsync(int productId)
        {
            return await repo.GetProductsAsync(productId);
        }

        public async Task<IEnumerable<Product>> getAllProductAsync()
        {
            return await repo.getAllProductAsync();
        }
    }

}
