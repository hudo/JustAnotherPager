using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JA.Sample.MVC6.Models;

namespace JA.Sample.MVC6.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int? page)
        {
            ViewBag.Page = page ?? 1;
            ViewBag.Total = 15;

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
