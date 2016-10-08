using JA.Sample.Model;
using Microsoft.AspNetCore.Mvc;

namespace JA.Sample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int? page)
        {
            var model = new PagerModel {CurrentPage = page.GetValueOrDefault(1), TotalPages = 20};

            return View(model);
        } 
    }
}
