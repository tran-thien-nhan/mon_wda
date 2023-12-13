using Microsoft.AspNetCore.Mvc;
using wda4.Models;

namespace wda4.Controllers
{
    public class UserController : Controller
    {
        private readonly UserDbContext db;

        public UserController(UserDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
