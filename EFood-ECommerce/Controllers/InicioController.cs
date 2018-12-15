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
            CustomerModel customerFace = (CustomerModel)Session["facebook"];
            CustomerModel customerTwitter = (CustomerModel)Session["twitter"];
            
            string name = string.Empty;
            if (customer != null)
            {
                name  = customer.CustomerName;
            }
            else if (customerFace == null)
            {
                name = customerFace.CustomerName;
            }
            else
            {
                name  = customerTwitter.CustomerName;
            }

            Session["NombreDeUsuario"] = name;
            return View();
        }
    }
}