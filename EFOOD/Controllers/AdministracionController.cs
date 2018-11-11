using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFOOD.Controllers
{
    public class AdministracionController : Controller
    {
        [HttpGet]
        public ActionResult Consecutivo()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TipoPrecio()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TarjetaCreditoDebito()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MediosPago()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TiqueteDescuento()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LineaComida()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Producto()
        {
            return View();
        }
    }
}