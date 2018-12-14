using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}