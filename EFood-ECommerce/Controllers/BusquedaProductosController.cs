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

        [HttpPost]
        public ActionResult BusquedaProductosAgregarCarrito(ProductoModel model)
        {
            CustomerModel usuarioLogueado = (CustomerModel)System.Web.HttpContext.Current.Session["Usuario"];
            if (CarritoModel.ExisteEnCarrito(model, usuarioLogueado.CustomerID))
            {
                AddAlertMessage("El producto ya existe en el carro");
                ViewBag.lista = LineaComidaModel.ObtenerLineasComida();
                ViewBag.listaProd = ProductoModel.ObtenerProductos();
                return View("BusquedaProductos");
            }
            
            CarritoModel.AddProductDB(model, usuarioLogueado.CustomerID);
            ViewBag.lista = LineaComidaModel.ObtenerLineasComida();
            ViewBag.listaProd = ProductoModel.ObtenerProductos();
            AddAlertMessage("El producto se ha agregado correctamente.");
            return View("BusquedaProductos");
        }

        private void AddAlertMessage(string message)
        {
            TempData["msg"] = "<script>alert('" + message + "');</script>";
        }
    }
}