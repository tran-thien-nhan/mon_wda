using hw1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hw1.Controllers
{
    public class NewsController : Controller
    {
        private readonly NewsContext db;

        public NewsController(NewsContext db)
        {
            this.db = db;
        }

        public IActionResult index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var acc = await db.Admins.SingleOrDefaultAsync(a => a.UserName == username && a.Password == password);
            if (acc != null)
            {
                HttpContext.Session.SetString("admin", username);
                return RedirectToAction("Admin");
            }
            ViewBag.error = "Login fail";
            return View("Index");
        }

        public IActionResult Admin()
        {
            if (HttpContext.Session.GetString("admin") == null)
            {
                return View("Index");
            }
            return View();
        }

        public async Task<IActionResult> ShowAllNews()
        {
            var list = await db.News.ToListAsync();
            return View(list);
        }

        public IActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNews(tbNews news)
        {
            db.News.Add(news);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
