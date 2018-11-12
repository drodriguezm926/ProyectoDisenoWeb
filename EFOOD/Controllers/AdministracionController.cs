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