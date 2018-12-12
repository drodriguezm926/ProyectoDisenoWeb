using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFOOD.Controllers
{
    public class MediosPagoController : Controller
    {
        // GET: MediosPago
        public ActionResult Index()
        {
            return View();
        }
        // Inicia controladores de tarjetaCreditoDebito
        [HttpGet]
        public ActionResult TarjetaCreditoDebito()
        {
            ViewBag.lista = TarjetaCreditoDebitoModel.ObtenerTarjetas();
            return View();
        }

        [HttpPost]
        public ActionResult TarjetaCreditoDebitoAdd(TarjetaCreditoDebitoModel model)
        {
            TarjetaCreditoDebitoModel.AddDB(model);
            ViewBag.lista = TarjetaCreditoDebitoModel.ObtenerTarjetas();
            return View("TarjetaCreditoDebito");
        }

        [HttpPost]
        public ActionResult TarjetaCreditoDebitoEdit(TarjetaCreditoDebitoModel model)
        {
            TarjetaCreditoDebitoModel.EditDB(model);
            ViewBag.lista = TarjetaCreditoDebitoModel.ObtenerTarjetas();
            return View("TarjetaCreditoDebito");
        }

        [HttpPost]
        public ActionResult TarjetaCreditoDebitoDelete(TarjetaCreditoDebitoModel model)
        {
            TarjetaCreditoDebitoModel.DeletetDB(model);
            ViewBag.lista = TarjetaCreditoDebitoModel.ObtenerTarjetas();
            return View("TarjetaCreditoDebito");
        }
        // Termina controladores de TarjetaCreditoDebito

        // Inicia controladores de tarjetaCreditoDebito
        [HttpGet]
        public ActionResult MediosPago()
        {
            ViewBag.lista = MediosPagoModel.ObtenerMediosDePago();
            return View();
        }

        [HttpPost]
        public ActionResult MediosPagoAdd(MediosPagoModel model)
        {
            MediosPagoModel.AddDB(model);
            ViewBag.lista = MediosPagoModel.ObtenerMediosDePago();
            return View("MediosPago");
        }

        [HttpPost]
        public ActionResult MediosPagoEdit(MediosPagoModel model)
        {
            MediosPagoModel.EditDB(model);
            ViewBag.lista = MediosPagoModel.ObtenerMediosDePago();
            return View("MediosPago");
        }

        [HttpPost]
        public ActionResult MediosPagoDelete(MediosPagoModel model)
        {
            MediosPagoModel.DeletetDB(model);
            ViewBag.lista = MediosPagoModel.ObtenerMediosDePago();
            return View("MediosPago");
        }
        // Termina controladores de tipo de precio.

        // Inicia controladores de tiquetes de descuento
        [HttpGet]
        public ActionResult TiqueteDescuento()
        {
            ViewBag.lista = TiqueteDescuentoModel.ObtenerTiquetesDescuento();
            return View();
        }

        [HttpPost]
        public ActionResult TiqueteDescuentoAdd(TiqueteDescuentoModel model)
        {
            TiqueteDescuentoModel.AddDB(model);
            ViewBag.lista = TiqueteDescuentoModel.ObtenerTiquetesDescuento();
            return View("TiqueteDescuento");
        }

        [HttpPost]
        public ActionResult TiqueteDescuentoEdit(TiqueteDescuentoModel model)
        {
            TiqueteDescuentoModel.EditDB(model);
            ViewBag.lista = TiqueteDescuentoModel.ObtenerTiquetesDescuento();
            return View("TiqueteDescuento");
        }

        [HttpPost]
        public ActionResult TiqueteDescuentoDelete(TiqueteDescuentoModel model)
        {
            TiqueteDescuentoModel.DeletetDB(model);
            ViewBag.lista = TiqueteDescuentoModel.ObtenerTiquetesDescuento();
            return View("TiqueteDescuento");
        }
        // Termina controladores de tiquetes de descuento
    }
}