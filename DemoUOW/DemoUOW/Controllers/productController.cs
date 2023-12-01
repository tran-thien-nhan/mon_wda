using DemoUOW.IRepository;
using DemoUOW.Models;
using DemoUOW.UnitOfWork;
using DemoUOW.UnitOfWorkRepository;
using Microsoft.AspNetCore.Mvc;

namespace DemoUOW.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork uni;

        public ProductController(IUnitOfWork uni)
        {
            this.uni = uni;
        }

        public async Task<IActionResult> Index()
        {
            var products = await uni.getAllProductAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await uni.AddProductAsync(product);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await uni.GetProductsAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            await uni.UpdateProductAsync(product);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await uni.GetProductsAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await uni.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }
    }

}
