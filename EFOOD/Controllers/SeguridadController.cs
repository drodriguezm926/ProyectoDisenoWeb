using EFOOD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFOOD.Controllers
{
    public class SeguridadController : Controller
    {
        [HttpGet]
        public ActionResult Usuario()
        {
            return View();
        }

        [HttpGet] 
        public ActionResult AsignarRol()
        {
            
            return View();
        }

        [HttpGet] 
        public ActionResult CambiarContrasena()
        {

            return View();
        }

        [HttpGet]
        public ActionResult CrearUsuario()
        {
            if (Session["Usuario"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            };
            
        }


        [HttpPost]
        public ActionResult CrearUsuario(Admin consumidor, string ContrasenaConfirma)
        {
            try
            {
                if (consumidor.PasswordHash.Equals(ContrasenaConfirma))
                {
                    addAlertMessage("Usuario ingresado correctamente");
                    Admin.InsertarUsuario(consumidor);
                }
                else
                {
                    addAlertMessage("Verifique contraseña");
                }
            }
            catch (Exception ex)
            {
                
                addAlertMessage("Ocurrio un error intente mas tarde");
            }

            return View();
        }

        [HttpGet]
        public ActionResult VerUsuario()
        {

            return View();
        }

        private void addAlertMessage(string message)
        {
            TempData["msg"] = "<script>alert('" + message + "');</script>";
        }
    }
}