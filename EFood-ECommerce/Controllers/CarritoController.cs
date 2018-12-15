using EFood_ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace EFood_ECommerce.Controllers
{

    public class CarritoController : Controller
    {
        // GET: Carrito
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult VerCarrito()
        {
            ViewBag.Carrito = CarritoModel.CargarCarrito();
            return View();
        }

        [HttpGet]
        public ActionResult Pagar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Pagar(PagarModel model)
        {
            return View();
        }

    }
}