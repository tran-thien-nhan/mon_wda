using DemoUOW.IRepository;
using DemoUOW.Models;
using DemoUOW.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoUOW.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext db;

        public ProductRepository(ProductDbContext db)
        {
            this.db = db;
        }

        public async Task<int> AddProductAsync(Product product)
        {
            try
            {
                db.Products.Add(product);
                return await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> DeleteProductAsync(int productId)
        {
            var pro = await db.Products.SingleOrDefaultAsync(p => p.Id == productId);
            if (pro != null)
            {
                db.Remove(pro);
                return await db.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }

        public async Task<IEnumerable<Product>> getAllProductAsync()
        {
            var proList = await db.Products.ToListAsync();
            return proList;
        }

        public async Task<Product> GetProductsAsync(int productId)
        {
            var pro = await db.Products.SingleOrDefaultAsync(p => p.Id == productId);
            return pro;
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            var pro = await db.Products.SingleOrDefaultAsync(p => p.Id == product.Id);
            if (pro != null)
            {
                pro.Name = product.Name;
                pro.Price = product.Price;
                return await db.SaveChangesAsync();
            }
            else
            {
                return -1;
            }
        }
    }
}
