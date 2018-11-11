using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFOOD.Controllers
{
    public class SeguridadController : Controller
    {
        [HttpGet]
        public ActionResult Usuario()
        {
            ViewBag.Title2 = "Si se puedo";
            return View();
        }

        [HttpGet] 
        public ActionResult AsignarRol()
        {
            
            return View();
        }

        [HttpGet] 
        public ActionResult CambiarContrasena()
        {

            return View();
        }
    }
}