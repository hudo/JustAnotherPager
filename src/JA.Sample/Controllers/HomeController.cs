using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JA.Sample.Model;
using Microsoft.AspNetCore.Mvc;

namespace JA.Sample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int? page)
        {
            if (!page.HasValue) page = 1;

            var model = new PagerModel {CurrentPage = page.Value, TotalPages = 20};
            return View(model);
        } 
    }
}
