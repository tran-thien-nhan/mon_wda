using hw_wda1.IRepository;
using hw_wda1.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace hw_wda1.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepo repo;
        private readonly AccountDbContext db;

        public AccountController(IAccountRepo repo, AccountDbContext db)
        {
            this.repo = repo;
            this.db = db;
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> ListUser()
        {
            var user = await repo.getAll();
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await db.Accounts.SingleOrDefaultAsync(a => a.Username == username && a.Password == password);
            if (user == null)
            {
                TempData["ErrorMessage"] = "Wrong username or password";
                return View();
            }
            else if(user.Role == true)
            {
                HttpContext.Session.SetString("id", user.Id.ToString()); // Sử dụng Id của user cho Session
                return RedirectToAction("Detail");
            }
            else
            {
                HttpContext.Session.SetString("id", user.Id.ToString()); // Sử dụng Id của user cho Session
                return RedirectToAction("ListUser");
            }
        }

        public async Task<IActionResult> Detail(int id)
        {
            // Lấy thông tin người dùng từ Session
            var accIdString = HttpContext.Session.GetString("id");

            // Kiểm tra xem người dùng đã đăng nhập hay chưa
            if (accIdString != null && int.TryParse(accIdString, out int accId))
            {
                // Gọi phương thức Get từ repo với id của người dùng
                var user = await repo.Get(accId);

                // Kiểm tra xem người dùng có tồn tại hay không
                if (user != null)
                {
                    return View("Detail",user);
                }
                else
                {
                    // Trả về một ActionResult khi không tìm thấy người dùng
                    return View("Login");
                }
            }
            else
            {
                // Trả về một ActionResult khi người dùng chưa đăng nhập
                return RedirectToAction("Login", "Account");
            }
        }

        public IActionResult Create()
        {
            var acc = HttpContext.Session.GetString("id");
            
            if (acc != null)
            {
                return View();
            }
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountTb account)
        {
            await repo.Create(account);
            return RedirectToAction("ListUser");
        }


        // Action đăng xuất
        public IActionResult Logout()
        {
            // Clear the user's session
            HttpContext.Session.Clear();

            // Sign out the user
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }
    }
}
