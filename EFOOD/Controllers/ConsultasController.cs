using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

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
            ViewBag.listaProducto = ProductoModel.ObtenerProductos();
            ViewBag.ListaFoodOption = LineaComidaModel.ObtenerLineasComida();
            return View();
        }

        [HttpPost]
        public ActionResult ProductosFiltrar(ProductoModel model)
        {
            ViewBag.listaProducto = ProductoModel.ObtenerProductosFiltrados(model);
            ViewBag.ListaFoodOption = LineaComidaModel.ObtenerLineasComida();
            return View("Productos");
        }

        [HttpGet]
        public ActionResult Bitacora()
        {
            ViewBag.Bitacora = BitacoraModel.CargarErrores();
            ViewBag.listaUsers = Admin.ObtenerAdmin();
            return View();
        }

        [HttpPost]
        public ActionResult Bitacora(BitacoraModel model)
        {
            ViewBag.Bitacora = BitacoraModel.FiltrarBitacora(model);
            ViewBag.listaUsers = Admin.ObtenerAdmin();
            return View("Bitacora");
        }

        [HttpGet]
        public ActionResult Errores()
        {
            ErrorLogModel model = new ErrorLogModel();
            ViewBag.Errores = ErrorLogModel.CargarErrores(); 
            return View();
        }

        [HttpPost]
        public ActionResult ErroresFiltro(ErrorLogModel model)
        {
            ViewBag.Errores = ErrorLogModel.FiltrarErrores(model);
            return View("Errores");
        }

    }
}