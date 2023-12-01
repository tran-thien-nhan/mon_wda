using Day4_Upload.IRepository;
using Day4_Upload.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day4_Upload.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo repo;

        IWebHostEnvironment env; //xử lý upload file vật lý vào wwwroot

        public ProductController(IProductRepo repo, IWebHostEnvironment env)
        {
            this.repo = repo;
            this.env = env;
        }

        public async Task<IActionResult> Index()
        {
            return View(await repo.GetProducts());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                //xử lý file: upload vào wwwroot
                var filename = GetUniqueFilename(product.UploadImage.FileName);
                // lấy đường dẫn vào thư mục images
                var upload = Path.Combine(env.WebRootPath, "images");
                var filepath = Path.Combine(upload, filename);
                //u file vật lý vào đường dẫn đã lấy
                var stream = new FileStream(filepath, FileMode.Create);
                await product.UploadImage.CopyToAsync(stream);

                //lưu dữ liệu vào db
                product.Image = filename;
                await repo.Create(product);
                return RedirectToAction("Index");
            }
            return View();
        }

        [NonAction]

        private string GetUniqueFilename(string filename)
        {
            filename = Path.GetFileName(filename);
            return Path.GetFileNameWithoutExtension(filename) + "-" + DateTime.Now.Ticks + Path.GetExtension(filename);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await repo.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await repo.GetProduct(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.UploadImage != null)
                {
                    //xử lý file: upload vào wwwroot
                    var filename = GetUniqueFilename(product.UploadImage.FileName);
                    // lấy đường dẫn vào thư mục images
                    var upload = Path.Combine(env.WebRootPath, "images");
                    var filepath = Path.Combine(upload, filename);
                    //u file vật lý vào đường dẫn đã lấy
                    var stream = new FileStream(filepath, FileMode.Create);
                    await product.UploadImage.CopyToAsync(stream);

                    //lưu dữ liệu vào db
                    product.Image = filename;
                }
                else
                {
                    //trường hợp ko edit hình
                    Product old = await repo.GetProduct(id);
                    product.Image = old.Image;
                }
                await repo.Update(product);
                return RedirectToAction("Index");   
            }
            return RedirectToAction("Index");
        }
    }
}
