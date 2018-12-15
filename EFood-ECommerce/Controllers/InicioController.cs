using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace EFood_ECommerce.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        public ActionResult Inicio()
        {
            CustomerModel customer = (CustomerModel)Session["Usuario"];
            Session["NombreDeUsuario"] = customer.CustomerName;
            return View();
        }
    }
}