using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFOOD.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }
        // Inicia controladores de producto
        [HttpGet]
        public ActionResult Producto()
        {
            ViewBag.lista = ProductoModel.ObtenerProductos();
            ViewBag.ListaFoodOption = LineaComidaModel.ObtenerLineasComida();
            return View();
        }

        [HttpPost]
        public ActionResult ProductoAdd(ProductoModel model, string id)
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

            ProductoModel.AddDB(model);
            ViewBag.lista = ProductoModel.ObtenerProductos();
            ViewBag.ListaFoodOption = LineaComidaModel.ObtenerLineasComida();
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