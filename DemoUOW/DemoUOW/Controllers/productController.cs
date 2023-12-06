using DemoUOW.IRepository;
using DemoUOW.Models;
using DemoUOW.Repository;
using DemoUOW.UnitOfWork;
using DemoUOW.UnitOfWorkRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoUOW.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork uni;
        private readonly ProductDbContext db;

        public ProductController(IUnitOfWork uni, ProductDbContext db)
        {
            this.uni = uni;
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            var products = await uni.ProductRepository.getAllProductAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                var result = await uni.ProductRepository.AddProductAsync(product);

                if (result > 0)
                {
                    TempData["SuccessMessage"] = "Thêm Thành công!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Không thể Thêm sản phẩm.";
                    return View();
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Đã xảy ra lỗi: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await uni.ProductRepository.GetProductsAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            await uni.ProductRepository.UpdateProductAsync(product);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await uni.ProductRepository.GetProductsAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                int result = await uni.ProductRepository.DeleteProductAsync(id);

                if (result > 0)
                {
                    TempData["SuccessMessage"] = "Xóa Thành công!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Không thể xóa sản phẩm.";
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Đã xảy ra lỗi: " + ex.Message;
                return RedirectToAction("Index");
            }
        }


        public async Task<IActionResult> ProductsAbovePrice(int threshold)
        {
            var productsAbovePrice = await uni.GetProductsAbovePriceAsync(threshold);
            return View(productsAbovePrice.ToList());
        }

        [NonAction]
        private bool CheckUniqueProduct(string name)
        {
            var isUnique = db.Products.SingleOrDefaultAsync(p => p.Name == name);
            return isUnique == null;
        }
    }

}
