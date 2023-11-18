using day2_CodeFirst.Data;
using day2_CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace day2_CodeFirst.Controllers
{

    public class StudentController : Controller
    {
        private readonly StudentContext db;

        public StudentController(StudentContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            //lấy danh sách student
            var students = await db.Students.ToListAsync();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            var stu = await db.Students.SingleOrDefaultAsync(x => x.Id == id);
            return View(stu);
        }

        [HttpPost]
        public async Task<IActionResult> SaveEdit(Student student)
        {
            var stu = await db.Students.SingleOrDefaultAsync(x => x.Id == student.Id);
            if (stu == null)
            {
                return View("Edit");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    stu.Name = student.Name;    
                    stu.Email = student.Email;  
                    stu.Phone = student.Phone;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Edit");
                }
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            var stu = await db.Students.SingleOrDefaultAsync(x => x.Id == id);
            db.Students.Remove(stu);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
