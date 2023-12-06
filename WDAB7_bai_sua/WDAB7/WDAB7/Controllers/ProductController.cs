using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WDAB7.Models;

namespace WDAB7.Controllers
{
    public class ProductController : Controller
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;
        public ProductController(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _dbContext.Products.ToListAsync();
            var productDTOS = _mapper.Map<List<ProductDTO>>(products);
            return View(productDTOS);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            if (ModelState.IsValid) {
                //thuc hien chuyen doi(mapping) tu doi tuong 
                //ProductDTO sang doi tuong Product
                var product = _mapper.Map<Product>(productDTO);
                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id) { 
        var product = await _dbContext.Products.SingleOrDefaultAsync(x => x.Id == id);
            if (product != null) {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id) {
            var product = await _dbContext.Products.FindAsync(id);
            //Map Product->ProductDTO
            var productDTO = _mapper.Map<ProductDTO>(product);
            return View(productDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO productDTO) {
            var existedProduct = await _dbContext.Products.FindAsync(productDTO.Id);

            if (ModelState.IsValid) {
                //C1
                //_mapper.Map(productDTO,existedProduct);
                //await _dbContext.SaveChangesAsync();
                //_mapper.Map<ProductDTO>(existedProduct);

                //C2
                //existedProduct.Name = productDTO.Name;
                //existedProduct.Price = productDTO.Price;
                //existedProduct.Description = productDTO.Description;
                //_dbContext.Products.Update(existedProduct);

                //C3
                //var productUpdate =  _mapper.Map<Product>(productDTO);
                //_dbContext.Products.Update(productUpdate);

                // C4
                var productUpdate =  _mapper.Map<Product>(productDTO);
                _dbContext.Entry(existedProduct).CurrentValues.SetValues(productUpdate);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
