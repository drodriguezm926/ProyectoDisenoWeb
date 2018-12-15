using EFood_ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using System.Web.Services;

namespace EFood_ECommerce.Controllers
{

    public class CarritoController : Controller
    {
        // GET: Carrito
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult VerCarrito()
        {
            Customer usuarioLogueado = (Customer)System.Web.HttpContext.Current.Session["Usuario"];
            ViewBag.Carrito = CarritoModel.CargarCarrito(usuarioLogueado.CustomerID);
            return View();
        }

        [HttpPost]
        public ActionResult VerCarritoEdit(ProductoModel model)
        {
            model.cantidad = Math.Abs(model.cantidad);
            Customer usuarioLogueado = (Customer)System.Web.HttpContext.Current.Session["Usuario"];
            CarritoModel.EditProductDB(model, usuarioLogueado.CustomerID);
            ViewBag.Carrito = CarritoModel.CargarCarrito(usuarioLogueado.CustomerID);
            return View("VerCarrito");
        }

        [HttpPost]
        public ActionResult VerCarritoDelete(ProductoModel model)
        {
            Customer usuarioLogueado = (Customer)System.Web.HttpContext.Current.Session["Usuario"];
            CarritoModel.DeleteProductDB(model, usuarioLogueado.CustomerID);
            ViewBag.Carrito = CarritoModel.CargarCarrito(usuarioLogueado.CustomerID);
            return View("VerCarrito");
        }

        [HttpGet]
        public ActionResult Pagar()
        {
            Customer usuarioLogueado = (Customer)System.Web.HttpContext.Current.Session["Usuario"];
            ViewBag.Carrito = CarritoModel.CargarCarrito(usuarioLogueado.CustomerID);
            return View();
        }

        [HttpPost]
        public ActionResult Pagar(PagarModel tarjeta, string fecha)
        {
            Customer usuarioLogueado = (Customer)System.Web.HttpContext.Current.Session["Usuario"];
            ViewBag.Carrito = CarritoModel.CargarCarrito(usuarioLogueado.CustomerID);


            if (tarjeta.cvv != null || tarjeta.numeroTarjeta != null)
            {
                //Tomo la fecha y realizo el split
                string[] lines = fecha.Split('/');
                //Convierto el array LINES en date formart
                tarjeta.fechaExpiracion = Convert.ToDateTime("1/" + lines[0] + "/" + lines[1]);
                //Se declara una varible vacia para el mensaje
                string mensaje = string.Empty;
                //Se consulta al WebService
                mensaje = PagarModel.actualizarMontoPut(tarjeta, mensaje);

                if (mensaje.Equals("OK"))
                {
                    //La compra es guardada
                    ViewBag.mensaje = "Transacción ha sido completada";
                }
                else
                {
                    //Se muestra el mensaje de error proveniente del webService
                    ViewBag.mensaje = mensaje;
                }
            }
            else
            {
                ViewBag.mensaje = "Verifica los datos de la tarjeta";
            }


            return View("Pagar");


        }

    }
}