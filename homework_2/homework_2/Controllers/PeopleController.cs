using homework_2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace homework_2.Controllers
{
    public class PeopleController : Controller
    {
        private readonly BankDbContext db;

        public PeopleController(BankDbContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Show()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                var people = await db.TbPeople.ToListAsync();
                return View(people);
            }
            return View("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var acc = await db.TbPeople.SingleOrDefaultAsync(a => a.Username == username && a.Password == password);
            if (acc != null)
            {
                HttpContext.Session.SetString("username", acc.Username);
                return RedirectToAction("Menu");
            }
            ViewBag.error = "Login fail";
            return View("Login");
        }

        public async Task<IActionResult> RemovePage()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                var people = await db.TbPeople.ToListAsync();
                return View(people);
            }
            return View("Login");
        }

        public async Task<IActionResult> Delete(string username)
        {
            var user = db.TbPeople.SingleOrDefaultAsync(u => u.Username == username);
            if (user != null)
            {
                db.Remove(user);
                db.SaveChangesAsync();
                return RedirectToAction("Show");
            }
            ViewBag.error = "remove fail";
            return View("RemovePage");
        }
    }
}
