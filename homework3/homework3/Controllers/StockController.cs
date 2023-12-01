using homework3.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace homework3.Controllers
{
    public class StockController : Controller
    {

        private readonly StockContext db;

        IWebHostEnvironment env;

        public StockController(StockContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var acc = await db.Accounts.SingleOrDefaultAsync(a => a.Username == username && a.Password == password);
            if (acc != null)
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("Listitem");
            }
            ViewBag.error = "Login fail";
            return View("Login");
        }

        public async Task<IActionResult> Listitem()
        {
            if (HttpContext.Session.GetString("username") == null || HttpContext.Session == null)
            {
                return Redirect("Login");
            }
            var list = await db.Items.ToListAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("username") == null || HttpContext.Session == null)
            {
                return View("Login");

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            try
            {
                var oldItemCode = CheckUniqueItemCode(item.ItemCode);

                if (!oldItemCode)
                {
                    ViewBag.error = "trùng mã sản phẩm";
                    return View("Error");
                }

                if (ModelState.IsValid)
                {
                    //xử lý file: upload vào wwwroot
                    var filename = GetUniqueFilename(item.UploadImage.FileName);
                    // lấy đường dẫn vào thư mục images
                    var upload = Path.Combine(env.WebRootPath, "images");
                    var filepath = Path.Combine(upload, filename);
                    //luu file vật lý vào đường dẫn đã lấy
                    var stream = new FileStream(filepath, FileMode.Create);
                    await item.UploadImage.CopyToAsync(stream);

                    //lưu dữ liệu vào db
                    item.Image = filename;
                    db.Items.Add(item);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Listitem");
                }
                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [NonAction]
        private string GetUniqueFilename(string filename)
        {
            filename = Path.GetFileName(filename);
            return Path.GetFileNameWithoutExtension(filename) + "-" + DateTime.Now.Ticks + Path.GetExtension(filename);
        }

        [NonAction]
        private bool CheckUniqueItemCode(string itemcode)
        {
            var isUniqueItemCode = db.Items.SingleOrDefault(u => u.ItemCode == itemcode);
            return isUniqueItemCode == null;
        }

        public async Task<IActionResult> Delete(string itemcode)
        {
            try
            {
                var product = await db.Items.SingleOrDefaultAsync(p => p.ItemCode == itemcode);
                if (product != null)
                {
                    db.Items.Remove(product);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Listitem");
                }
                return View("Listitem");
            }
            catch
            {
                return View("Error");
            }
        }

        // Action đăng xuất
        public IActionResult Logout()
        {
            // Clear the user's session
            HttpContext.Session.Clear();

            // Sign out the user
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
