using Day5_demoAuthorize.Models;
using Day5_demoAuthorize.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day5_demoAuthorize.Controllers
{
    public class AccountController : Controller
    {
        private readonly DemoAuthorizeContext db;
        SecurityManager SecurityManager = new SecurityManager();

        public AccountController(DemoAuthorizeContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var account = await ProcessLogin(username, password);
            if (account == null)
            {
                ViewBag.error = "Invalid username or password";
                return View("Index");
            }
            else
            {
                await SecurityManager.SignIn(this.HttpContext, account);
                return RedirectToAction("Welcome");
            }
        }

        [NonAction]
        private async Task<Account> ProcessLogin(string username, string password)
        {
            var account = await db.Accounts.Include(a => a.AccountRoles).ThenInclude(a => a.Role).SingleOrDefaultAsync(a => a.Usename == username);
            if (account != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, account.Password))
                {
                    return account;
                }
            }
            return null;
        }

        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult AccessDenied() { return View(); }

        public async Task<IActionResult> SignOut()
        {
            await SecurityManager.SignOut(this.HttpContext);
            return RedirectToAction("Index");
        }
    }
}
