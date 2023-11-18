using Day3_demoFilter.Filters;
using Day3_demoFilter.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Day3_demoFilter.Controllers
{
    [AddHeader("Nhan","T1.2210.A1")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}