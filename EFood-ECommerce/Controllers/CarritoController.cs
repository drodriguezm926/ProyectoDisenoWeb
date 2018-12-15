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
            Customer usuarioLogueado = (Customer)System.Web.HttpContext.Current.Session["Usuario"];
            ViewBag.Carrito = CarritoModel.CargarCarrito(usuarioLogueado.CustomerID);
            return View();
        }

        [HttpPost]
        public ActionResult VerCarritoDelete(ProductoModel model)
        {
            Customer usuarioLogueado = (Customer)System.Web.HttpContext.Current.Session["Usuario"];
            CarritoModel.DeleteProductDB(model, usuarioLogueado.CustomerID);
            ViewBag.Carrito = CarritoModel.CargarCarrito(usuarioLogueado.CustomerID);
            return View("VerCarrito");
        }

        [HttpGet]
        public ActionResult Pagar()
        {
            Customer usuarioLogueado = (Customer)System.Web.HttpContext.Current.Session["Usuario"];
            ViewBag.Carrito = CarritoModel.CargarCarrito(usuarioLogueado.CustomerID);
            return View();
        }

        [HttpPost]
        public ActionResult Pagar(PagarModel model)
        {
            Customer usuarioLogueado = (Customer)System.Web.HttpContext.Current.Session["Usuario"];
            ViewBag.Carrito = CarritoModel.CargarCarrito(usuarioLogueado.CustomerID);
            return View("Pagar");
        }

    }
}