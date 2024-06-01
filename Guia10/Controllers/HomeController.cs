using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Guia10.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Sistema de Gestion de clinica.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Pagina de Informacion.";

            return View();
        }
    }
}