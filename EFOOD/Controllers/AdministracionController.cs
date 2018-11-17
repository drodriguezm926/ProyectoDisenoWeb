using EFOOD.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            ViewBag.lista = TarjetaCreditoDebitoModel.obtenerTarjetas();
            return View();
        }

        [HttpPost]
        public ActionResult TarjetaCreditoDebitoAdd(TarjetaCreditoDebitoModel model)
        {
            TarjetaCreditoDebitoModel.addDB(model);
            ViewBag.lista = TarjetaCreditoDebitoModel.obtenerTarjetas();
            return View("TarjetaCreditoDebito");
        }

        [HttpPost]
        public ActionResult TarjetaCreditoDebitoEdit(TarjetaCreditoDebitoModel model)
        {
            TarjetaCreditoDebitoModel.editDB(model);
            ViewBag.lista = TarjetaCreditoDebitoModel.obtenerTarjetas();
            return View("TarjetaCreditoDebito");
        }

        [HttpPost]
        public ActionResult TarjetaCreditoDebitoDelete(TarjetaCreditoDebitoModel model)
        {
            TarjetaCreditoDebitoModel.deletetDB(model);
            ViewBag.lista = TarjetaCreditoDebitoModel.obtenerTarjetas();
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
            MediosPagoModel.addDB(model);
            ViewBag.lista = MediosPagoModel.ObtenerMediosDePago();
            return View("MediosPago");
        }

        [HttpPost]
        public ActionResult MediosPagoEdit(MediosPagoModel model)
        {
            MediosPagoModel.editDB(model);
            ViewBag.lista = MediosPagoModel.ObtenerMediosDePago();
            return View("MediosPago");
        }

        [HttpPost]
        public ActionResult MediosPagoDelete(MediosPagoModel model)
        {
            MediosPagoModel.deletetDB(model);
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
            TiqueteDescuentoModel.addDB(model);
            ViewBag.lista = TiqueteDescuentoModel.ObtenerTiquetesDescuento();
            return View("TiqueteDescuento");
        }

        [HttpPost]
        public ActionResult TiqueteDescuentoEdit(TiqueteDescuentoModel model)
        {
            TiqueteDescuentoModel.editDB(model);
            ViewBag.lista = TiqueteDescuentoModel.ObtenerTiquetesDescuento();
            return View("TiqueteDescuento");
        }

        [HttpPost]
        public ActionResult TiqueteDescuentoDelete(TiqueteDescuentoModel model)
        {
            TiqueteDescuentoModel.deletetDB(model);
            ViewBag.lista = TiqueteDescuentoModel.ObtenerTiquetesDescuento();
            return View("TiqueteDescuento");
        }
        // Termina controladores de tiquetes de descuento

        // Inicia controladores de linea de comida
        [HttpGet]
        public ActionResult LineaComida()
        {
            ViewBag.listaLineaComida = LineaComidaModel.ObtenerLineasComida();
            return View();
        }

        [HttpPost]
        public ActionResult LineaComidaAdd(LineaComidaModel model)
        {
            LineaComidaModel.addDB(model);
            ViewBag.listaLineaComida = LineaComidaModel.ObtenerLineasComida();
            return View("LineaComida");
        }

        [HttpPost]
        public ActionResult LineaComidaEdit(LineaComidaModel model)
        {
            LineaComidaModel.editDB(model);
            ViewBag.listaLineaComida = LineaComidaModel.ObtenerLineasComida();
            return View("LineaComida");
        }

        [HttpPost]
        public ActionResult LineaComidaDelete(LineaComidaModel model)
        {
            LineaComidaModel.deletetDB(model);
            ViewBag.listaLineaComida = LineaComidaModel.ObtenerLineasComida();
            return View("LineaComida");
        }
        // Termina controladores de linea de comida

        // Inicia controladores de producto
        [HttpGet]
        public ActionResult Producto()
        {
            ViewBag.lista = ProductoModel.ObtenerProductos();
            ViewBag.ListaFoodOption = LineaComidaModel.ObtenerLineasComida();
            return View();
        }

        [HttpPost]
        public ActionResult ProductoAdd(ProductoModel model)
        {

            string cadenaRuta = string.Empty;


            if (model.Archivo != null && model.Archivo.ContentLength > 0)
            {
                var fileName = Path.GetFileName(model.Archivo.FileName);

                var rutaImagen = Path.Combine(Server.MapPath("~/Asset/Images/Producto"), fileName);
                cadenaRuta = "~/Asset/Images/Producto/" + fileName;
                model.Archivo.SaveAs(rutaImagen);
                model.ProductImage = cadenaRuta;
            }

            ProductoModel.addDB(model);
            ViewBag.lista = ProductoModel.ObtenerProductos();
            ViewBag.ListaFoodOption = LineaComidaModel.ObtenerLineasComida();
            return View("Producto");
        }

        [HttpPost]
        public ActionResult ProductoEdit(ProductoModel model)
        {
            ProductoModel.editDB(model);
            ViewBag.lista = ProductoModel.ObtenerProductos();
            ViewBag.ListaFoodOption = LineaComidaModel.ObtenerLineasComida();
            return View("Producto");
        }

        [HttpPost]
        public ActionResult ProductoDelete(ProductoModel model)
        {
            ProductoModel.deletetDB(model);
            ViewBag.lista = ProductoModel.ObtenerProductos();
            ViewBag.ListaFoodOption = LineaComidaModel.ObtenerLineasComida();
            return View("Producto");
        }
        // Termina controladores de producto
    }
}