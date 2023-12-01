using HW4_5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HW4_5.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerDbContext db;

        public CustomerController(CustomerDbContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            var cus = await db.Customers.ToListAsync();
            return View(cus);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            db.Customers.Add(customer);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}
