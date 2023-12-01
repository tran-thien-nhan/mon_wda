using Microsoft.AspNetCore.Mvc;

namespace Day4_Security.Controllers
{
    //[Route("dangnhap")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckLogin(string username, string password)
        {
            if ("aptech" == username && "123" == password)
            {
                // gắn session
                HttpContext.Session.SetString("username", username);
                //return View("Welcome");
                return Redirect("/admin/product");
            }
            else if ("trnthien97" == username && "1234" == password)
            {
                // gắn session
                HttpContext.Session.SetString("username", username);
                //return View("Welcome");
                return Redirect("/user/product");
            }
            else
            {
                ViewBag.error = "Invalid username or password";
                return View("Index");
            }
        }
    }
}
