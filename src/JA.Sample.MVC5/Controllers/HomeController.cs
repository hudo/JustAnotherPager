using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JA.Sample.MVC5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? page)
        {
            ViewBag.Page = page ?? 1;
            ViewBag.Total = 15;

            return View();
        }
    }
}