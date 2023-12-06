using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WDA1.Models;

namespace WDA1.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly DatabaseContext db;

        public AdminController(DatabaseContext db)
        {
            this.db = db;
        }

        [Route("List")]
        public async Task<IActionResult> Index()
        {
            var list = await db.Accounts.ToListAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            if(HttpContext.Session.GetString("role") != "Admin")
            {
                return Redirect("/Account");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountTb account)
        {
            if(ModelState.IsValid)
            {
                db.Accounts.Add(account);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
