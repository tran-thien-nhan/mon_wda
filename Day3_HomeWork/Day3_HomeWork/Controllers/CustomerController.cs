using Day3_HomeWork.IRepository;
using Day3_HomeWork.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day3_HomeWork.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepo repo;

        public CustomerController(ICustomerRepo repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await repo.getAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            await repo.Create(customer);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await repo.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await repo.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> SaveEdit(Customer customer)
        {
            await repo.Edit(customer);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Search(string sname)
        {
            var list = await repo.SearchByName(sname);
            return View("Index", list);
        }
    }
}
