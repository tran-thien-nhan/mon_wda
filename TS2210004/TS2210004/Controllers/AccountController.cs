using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TS2210004.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TS2210004.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountDbContext db;

        public AccountController(AccountDbContext db)
        {
            this.db = db;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string accNo, string pinCode)
        {
            if (ModelState.IsValid)
            {
                var acc = await db.Accounts.SingleOrDefaultAsync(a => a.AccountNo == accNo && a.PinCode == pinCode);
                if (acc != null)
                {
                    HttpContext.Session.SetString("AccountNo", acc.AccountNo);
                    HttpContext.Session.SetString("AccountName", acc.AccountName);
                    if (acc.Role == true)
                    {
                        return RedirectToAction("AccountList");
                    }
                    else
                    {
                        return RedirectToAction("AccountDetails", new { id = acc.AccountNo, role = acc.Role });
                    }
                }
                ViewBag.ErrorMessage = "invalid account!";
                return View();
            }
            return View();
        }

        public async Task<IActionResult> AccountList()
        {
            if (HttpContext.Session.GetString("AccountNo") != null)
            {
                ViewBag.SuccessMessage = "Đăng nhập thành công!";
                var list = await db.Accounts.Where(a => a.Role == false).OrderBy(a => a.Balance).ToListAsync();
                return View(list);
            }
            return View("Login");
        }

        public async Task<IActionResult> AccountDetails(String id)
        {
            if (HttpContext.Session.GetString("AccountNo") != null)
            {
                ViewBag.SuccessMessage = "Đăng nhập thành công!";
                var acc = await db.Accounts.SingleOrDefaultAsync(a => a.AccountNo == id);
                return View(acc);
            }
            return View("Login");
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(Account account)
        {
            if (ModelState.IsValid)
            {

                if (!await IsAccountNoUnique(account.AccountNo))
                {
                    db.Accounts.Add(account);
                    await db.SaveChangesAsync();
                    ViewBag.SuccessMessage = "đăng ký thành công!";
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.ErrorMessage = "đăng ký thất bại!";
                    return View();
                }

            }
            return RedirectToAction("Login", account);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        public async Task<bool> IsAccountNoUnique(string accountNo)
        {
            bool isUnique = await db.Accounts.AnyAsync(x => x.AccountNo == accountNo);
            return isUnique;
        }
    }
}
