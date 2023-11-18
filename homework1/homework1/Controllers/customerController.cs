using homework1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace homework1.Controllers
{
    public class customerController : Controller
    {
        private readonly CustomerContext db;

        public customerController(CustomerContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            //lấy danh sách student
            var customers = await db.Customers.ToListAsync();
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
