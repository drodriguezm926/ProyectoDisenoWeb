using Models;
using ProjectHelpers.AppData;
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
            ViewBag.lista = ConsecutivoModel.ObtenerConsecutivos();
            return View();   
        }

        [HttpPost]
        public ActionResult ConsecutivoAdd(ConsecutivoModel model)
        {
            ConsecutivoModel.AddDB(model);
            ViewBag.lista = ConsecutivoModel.ObtenerConsecutivos();

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
            TipoPrecioModelo.AddDB(model);
            ViewBag.lista = TipoPrecioModelo.ObtenerTerritorio();
            return View("TipoPrecio");
        }

        [HttpPost]
        public ActionResult TipoPrecioEdit(TipoPrecioModelo model)
        {
            TipoPrecioModelo.EditDB(model);
            ViewBag.lista = TipoPrecioModelo.ObtenerTerritorio();
            return View("TipoPrecio");
        }

        [HttpPost]
        public ActionResult TipoPrecioDelete(TipoPrecioModelo model)
        {
            TipoPrecioModelo.DeletetDB(model);
            ViewBag.lista = TipoPrecioModelo.ObtenerTerritorio();
            return View("TipoPrecio");
        }
        // Termina controladores de tipo de precio.

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
            LineaComidaModel.AddDB(model);
            ViewBag.listaLineaComida = LineaComidaModel.ObtenerLineasComida();
            return View("LineaComida");
        }

        [HttpPost]
        public ActionResult LineaComidaEdit(LineaComidaModel model)
        {
            LineaComidaModel.EditDB(model);
            ViewBag.listaLineaComida = LineaComidaModel.ObtenerLineasComida();
            return View("LineaComida");
        }

        [HttpPost]
        public ActionResult LineaComidaDelete(LineaComidaModel model)
        {
            LineaComidaModel.DeletetDB(model);
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
            ViewBag.listaTipoPrecios = TipoPrecioModelo.ObtenerTerritorio();

            return View();
        }

        [HttpPost]
        public ActionResult ProductoAdd(ProductoModel model, TipoPrecioToProduct modeloTipoPrecio)
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

            ProductoModel.AddDB(model, modeloTipoPrecio);
            ViewBag.lista = ProductoModel.ObtenerProductos();
            ViewBag.ListaFoodOption = LineaComidaModel.ObtenerLineasComida();
            ViewBag.listaTipoPrecios = TipoPrecioModelo.ObtenerTerritorio();

            return View("Producto");
        }

        [HttpPost]
        public ActionResult ProductoEdit(ProductoModel model)
        {
            ProductoModel.EditDB(model);
            ViewBag.lista = ProductoModel.ObtenerProductos();
            ViewBag.ListaFoodOption = LineaComidaModel.ObtenerLineasComida();
            return View("Producto");
        }

        [HttpPost]
        public ActionResult ProductoDelete(ProductoModel model)
        {
            ProductoModel.DeletetDB(model);
            ViewBag.lista = ProductoModel.ObtenerProductos();
            ViewBag.ListaFoodOption = LineaComidaModel.ObtenerLineasComida();
            return View("Producto");
        }
        // Termina controladores de producto
    }
}