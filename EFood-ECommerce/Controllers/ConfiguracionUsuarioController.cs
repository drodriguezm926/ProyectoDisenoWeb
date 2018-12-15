using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace EFood_ECommerce.Controllers
{
    public class ConfiguracionUsuarioController : Controller
    {
        // GET: ConfiguracionUsuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Configuracion()
        {
            return View();
        }

        public ActionResult CambiarContrasena(CustomerModel customer)
        {
            CustomerModel current = (CustomerModel)System.Web.HttpContext.Current.Session["Usuario"];
            if (current.ContrasenaEmail != customer.ContrasenaEmail)
            {
                AddAlertMessage("Contraseña actual incorrecta.");
                return RedirectToAction("Configuracion", "ConfiguracionUsuario");
            }
            else
            {
                if(customer.ContrasenaNueva != customer.ConfirmaContrasena)
                {
                    AddAlertMessage("Las contraseñas no coinciden.");
                    return RedirectToAction("Configuracion", "ConfiguracionUsuario");
                }
                else
                {
                    CustomerModel usuarioLogueado = (CustomerModel)System.Web.HttpContext.Current.Session["Usuario"];
                    customer.CustomerID = usuarioLogueado.CustomerID;
                    CustomerModel.CambiarContrasena(customer);
                    AddAlertMessage("Se ha cambiado la contraseña.");
                    return RedirectToAction("Configuracion", "ConfiguracionUsuario");
                }
            }
        }

        private void AddAlertMessage(string message)
        {
            TempData["msg"] = "<script>alert('" + message + "');</script>";
        }
    }
}