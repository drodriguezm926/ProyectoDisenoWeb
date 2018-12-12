using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EFOOD.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // Limpia la sesion
            return RedirectToAction("Index", "Login");
        }


        // GET: Login
        public ActionResult LoginAction(Admin admin)
        {
            try
            {
                List<Admin> usuario = Admin.LoginUsuario(admin.Username, admin.PasswordHash);

                if (usuario != null)
                {
                    if (usuario.Count > 0)
                    {
                        Session["Usuario"] = usuario.FirstOrDefault();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        AddAlertMessage("Usuario o contraseña incorrectos");
                        return Redirect("~/Login/index");
                    }
                }
                else
                {
                    AddAlertMessage("Usuario o contraseña incorrectos");
                    return Redirect("~/Login/index");
                }
            }
            catch (Exception ex)
            {
                AddAlertMessage("Error, intente mas tarde. Detalles: " + ex.Message);
                return Redirect("~/Login/index");
            }
        }



        private void AddAlertMessage(string message)
        {
            TempData["msg"] = "<script>alert('" + message + "');</script>";
        }
    }
}