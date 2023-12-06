using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wda2.Models;

namespace wda2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext db;

        public EmployeeController(EmployeeDbContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            var emp = await db.Employees.Include(e => e.Position).ToListAsync();
            return View(emp);
        }

        public async Task<IActionResult> Edit(String id)
        {
            // Lấy thông tin nhân viên từ cơ sở dữ liệu
            var emp = await db.Employees.Include(e => e.Position).SingleOrDefaultAsync(e => e.Id == id);

            // Kiểm tra xem nhân viên có tồn tại hay không
            if (emp != null)
            {
                // Lấy danh sách vị trí từ cơ sở dữ liệu
                var positions = await db.Positions.ToListAsync(); // Giả sử có DbSet<Position> trong DbContext

                // Truyền danh sách vị trí vào ViewBag để sử dụng trong view
                ViewBag.Positions = positions;

                // Truyền thông tin nhân viên vào view để hiển thị trong form
                return View(emp);
            }

            // Trong trường hợp có lỗi hoặc không có dữ liệu, có thể xử lý tùy thuộc vào yêu cầu của bạn
            return View("Index");
        }


        [HttpPost]
        public async Task<IActionResult> SaveEdit(Employee employee)
        {
            try
            {
                var emp = await db.Employees.Include(e => e.Position).SingleOrDefaultAsync(e => e.Id == employee.Id);
                if (emp != null)
                {
                    emp.Name = employee.Name;
                    emp.PositionId = employee.PositionId;
                    db.Update(emp);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                return NotFound(); // Trả về 404 Not Found nếu không tìm thấy nhân viên
            }
            catch (DbUpdateException)
            {
                // Xử lý lỗi lưu vào cơ sở dữ liệu, có thể là do việc vi phạm ràng buộc duy nhất, khóa chính, vv.
                // Bạn có thể thêm mã lỗi tùy thuộc vào yêu cầu cụ thể của bạn.
                // Trong trường hợp này, tôi trả về một giá trị âm để chỉ ra rằng có lỗi xảy ra.
                return View("Edit");
            }
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
