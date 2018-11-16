using EFOOD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFOOD.Controllers
{
    public class AdministracionController : Controller
    {
        // Inicia controladores de consecutivo.
        [HttpGet]
        public ActionResult Consecutivo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConsecutivoAdd(ConsecutivoModel model)
        {
            ConsecutivoModel.addDB(model);
            var data = ViewBag.lala;

            return View("Consecutivo");
        }
        // Termina controladores de consecutivos

        // Inicia controladores de tipo de precio.
        [HttpGet]
        public ActionResult TipoPrecio()
        {
            ViewBag.lista = TipoPrecioModelo.ObtenerTerritorio();
            return View();
        }

        [HttpPost]
        public ActionResult TipoPrecioAdd(TipoPrecioModelo model)
        {
            TipoPrecioModelo.addDB(model);
            ViewBag.lista = TipoPrecioModelo.ObtenerTerritorio();
            return View("TipoPrecio");
        }

        [HttpPost]
        public ActionResult TipoPrecioEdit(TipoPrecioModelo model)
        {
            TipoPrecioModelo.editDB(model);
            ViewBag.lista = TipoPrecioModelo.ObtenerTerritorio();
            return View("TipoPrecio");
        }

        [HttpPost]
        public ActionResult TipoPrecioDelete(TipoPrecioModelo model)
        {
            TipoPrecioModelo.deletetDB(model);
            ViewBag.lista = TipoPrecioModelo.ObtenerTerritorio();
            return View("TipoPrecio");
        }
        // Termina controladores de tipo de precio.

        // Inicia controladores de tarjetaCreditoDebito
        [HttpGet]
        public ActionResult TarjetaCreditoDebito()
        {
            
            return View();
        }
        // Termina controladores de TarjetaCreditoDebito

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

        // Inicia controladores de producto
        [HttpGet]
        public ActionResult Producto()
        {
            ViewBag.lista = ProductoModel.ObtenerProductos();
            return View();
        }

        [HttpPost]
        public ActionResult ProductoAdd(ProductoModel model)
        {
            ProductoModel.addDB(model);
            ViewBag.lista = ProductoModel.ObtenerProductos();
            return View("Producto");
        }

        [HttpPost]
        public ActionResult ProductoEdit(ProductoModel model)
        {
            ProductoModel.editDB(model);
            ViewBag.lista = ProductoModel.ObtenerProductos();
            return View("Producto");
        }

        [HttpPost]
        public ActionResult ProductoDelete(ProductoModel model)
        {
            ProductoModel.deletetDB(model);
            ViewBag.lista = ProductoModel.ObtenerProductos();
            return View("Producto");
        }
        // Termina controladores de producto
    }
}