using DemoUOW.IRepository;
using DemoUOW.Models;
using DemoUOW.Repository;
using DemoUOW.UnitOfWorkRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace DemoUOW.UnitOfWork
{
    public class UnitOfWorkRepo : IUnitOfWork
    {
        private readonly ProductDbContext db;

        public UnitOfWorkRepo(ProductDbContext db, IProductRepository productRepository)
        {
            this.db = db;
            ProductRepository = productRepository;
        }

        public IProductRepository ProductRepository { get; private set; }

        public async Task<IEnumerable<Product>> GetProductsAbovePriceAsync(int threshold)
        {
            var products = await db.Products
                .Where(x => x.Price > threshold)
                .ToListAsync();

            return products ?? Enumerable.Empty<Product>();
        }

        public async Task<int> Save()
        {
            return await db.SaveChangesAsync();
        }
    }
}
