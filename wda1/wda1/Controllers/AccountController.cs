using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wda1.Models;

namespace wda1.Controllers
{
    public class AccountController : Controller
    {
        private readonly DatabaseContext db;

        public AccountController(DatabaseContext db)
        {
            this.db = db;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var acc = await db.Accounts.SingleOrDefaultAsync(u => u.Username == username && u.Password == password);
            if (acc == null)
            {
                ViewBag.error = "Login fail";
                return View("Login");
            }

            HttpContext.Session.SetString("role", acc.Role);

            if (acc.Role == "User")
            {
                return Redirect($"Detail/{acc.Id}");
            }
            else
            {
                return Redirect("/Admin/Index");
            }
        }

        public async Task<IActionResult> Detail(int id)
        {
            var acc = await db.Accounts.SingleOrDefaultAsync(a => a.Id.Equals(id));
            return View(acc);
        }
    }
}
