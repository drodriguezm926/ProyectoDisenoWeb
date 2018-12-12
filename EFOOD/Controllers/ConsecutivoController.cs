using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFOOD.Controllers
{
    public class ConsecutivoController : Controller
    {
        // GET: Consecutivos
        public ActionResult Index()
        {
            return View();
        }
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

    }
}