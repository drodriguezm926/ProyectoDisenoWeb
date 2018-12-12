using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFood_ECommerce.Controllers
{
    public class BusquedaProductoController : Controller
    {
        // GET: BusquedaProducto
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BusquedaProducto()
        {
            ViewBag.lista = LineaComidaModel.ObtenerLineasComida();
            ViewBag.listaProd = ProductoModel.ObtenerProductos();
            return View();
        }

        public ActionResult BusquedaProductos()
        {

            return View();
        }


        public ActionResult AgregarCarrito(string id)
        {

            return View();
        }
    }
} 