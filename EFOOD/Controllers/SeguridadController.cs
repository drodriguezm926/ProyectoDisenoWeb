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

        [HttpPost]
        public ActionResult AsignarRol(RolModel model)
        {

            if (Admin.AsignarRol(model.userID, model.RoleID))
            {
                AddAlertMessage("Rol cambiado correctamente");
            }
            else
            {
                AddAlertMessage("Error al cambiar rol");
            }
            return View();
        }


        [HttpGet] 
        public ActionResult CambiarContrasena()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CambiarContrasena(string ContrasenaAnterior, string Contrasena, string ContrasenaConfirma)
        {
            Admin usuario = (Admin)Session["Usuario"];
            if (usuario.PasswordHash.Equals(ContrasenaAnterior))
            {
                if (Contrasena.Equals(ContrasenaConfirma))
                {

                    if (Admin.CambiarContrasena(ContrasenaAnterior, Contrasena))
                    {
                        AddAlertMessage("Contraseña cambiada correctamente");
                    }
                    else
                    {
                        AddAlertMessage("Error al cambiar contraseña");
                    }
                }
                else
                {
                    AddAlertMessage("Verifique la confirmación de su nueva contraseña");
                }
            }
            else
            {
                AddAlertMessage("Verifique su contraseña actual");
            }
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
                    AddAlertMessage("Usuario ingresado correctamente");
                    Admin.InsertarUsuario(consumidor);
                }
                else
                {
                    AddAlertMessage("Verifique contraseña");
                }
            }
            catch (Exception ex)
            {
                
                AddAlertMessage("Ocurrio un error intente mas tarde. Detalles: " + ex.Message);
            }

            return View();
        }

        [HttpGet]
        public ActionResult VerUsuario()
        {

            return View();
        }

        private void AddAlertMessage(string message)
        {
            TempData["msg"] = "<script>alert('" + message + "');</script>";
        }
    }
}