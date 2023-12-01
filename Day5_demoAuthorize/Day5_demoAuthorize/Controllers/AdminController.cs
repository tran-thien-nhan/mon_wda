using Day5_demoAuthorize.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day5_demoAuthorize.Controllers
{
    public class AdminController : Controller
    {
        DemoAuthorizeContext db;

        public AdminController(DemoAuthorizeContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            var accounts = await db.Accounts.Include(a => a.AccountRoles).ThenInclude(a => a.Role).ToListAsync();
            return View(accounts);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
    }
}
