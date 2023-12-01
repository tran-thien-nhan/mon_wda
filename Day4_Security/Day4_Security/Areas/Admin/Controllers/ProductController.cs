using Microsoft.AspNetCore.Mvc;

namespace Day4_Security.Areas.Admin.Controllers
{
    // Đây là attribute [Area] đánh dấu rằng controller và các action trong nó thuộc vùng "admin".
    [Area("admin")]

    // Đây là attribute [Route] để định nghĩa phần đường dẫn (route) của controller.
    // Trong trường hợp này, controller được ánh xạ vào đường dẫn "/admin/product".
    [Route("admin/product")]

    public class ProductController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
