using AutoMapper;
using demo_DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo_DTO.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper mapper;
        private readonly productContext db;

        public ProductController(IMapper mapper, productContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            var productsdb = await db.Products.ToListAsync();
            var productDTO = mapper.Map<List<productDTO>>(productsdb);
            return View(productDTO);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(productDTO pDTO)
        {
            var product = mapper.Map<Product>(pDTO);
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await db.Products.FirstOrDefaultAsync(x => x.Id == id);
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return View();
        }
    }
}
