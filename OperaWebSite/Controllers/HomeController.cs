using Microsoft.AspNetCore.Mvc;
using System;

namespace OperaWebSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Nombre = "Bienvenido al sistema de Operas";
            ViewBag.Fecha = DateTime.Now.ToString();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
