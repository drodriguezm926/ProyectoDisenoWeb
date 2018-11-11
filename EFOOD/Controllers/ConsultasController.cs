using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFOOD.Controllers
{
    public class ConsultasController : Controller
    {
        [HttpGet]
        public ActionResult Pedidos()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Productos()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Bitacora()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Errores()
        {
            return View();
        }
    }
}