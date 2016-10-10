using JA.Sample.Model;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

    public static class B
    {
        public static IHtmlContent Bla(this IHtmlHelper helper)
        {
            return helper.Raw("asd");
        }
    }
}
