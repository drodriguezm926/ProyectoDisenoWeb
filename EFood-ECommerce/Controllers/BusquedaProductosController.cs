using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace EFood_ECommerce.Controllers
{
    public class BusquedaProductosController : Controller
    {
        // GET: BusquedaProductos
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BusquedaProductos()
        {
            ViewBag.lista = LineaComidaModel.ObtenerLineasComida();
            ViewBag.listaProd = ProductoModel.ObtenerProductos();
            return View();
        }
    }
}