using Day5_HomeWork5.Data;
using Day5_HomeWork5.IRepository;
using Day5_HomeWork5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day5_HomeWork5.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepo repo;

        public StudentController(IStudentRepo repo)
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

        public async Task<IActionResult> Create(Student student)
        {
            await repo.Create(student);
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
        public async Task<IActionResult> SaveEdit(Student student)
        {
            await repo.Edit(student);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await repo.Get(id));
        }
    }
}
