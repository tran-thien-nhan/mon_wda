using Day4_Upload.IRepository;
using Day4_Upload.Models;
using Microsoft.EntityFrameworkCore;

namespace Day4_Upload.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly ProductDbContext db;

        public ProductRepo(ProductDbContext db)
        {
            this.db = db;
        }
        public async Task<int> Create(Product product)
        {
            db.Products.Add(product);
            return await db.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            //var product = db.Products.FirstOrDefault(x => x.Id == id);
            var product = await GetProduct(id);
            if (product == null)
            {
                return -1;
            }
            else
            {
                db.Products.Remove(product);
                return await db.SaveChangesAsync();
            }

        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await db.Products.SingleOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await db.Products.ToListAsync();
        }

        public async Task<int> Update(Product product)
        {
            var oldProduct = await GetProduct(product.Id);
            if (oldProduct != null)
            {
                oldProduct.Name = product.Name;
                oldProduct.Price = product.Price;
                oldProduct.Image = product.Image;
                return await db.SaveChangesAsync();
            }
            return -1;
        }
    }
}
