using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFOOD.Controllers
{
    public class LineasComidaController : Controller
    {
        // GET: LineasComida
        public ActionResult Index()
        {
            return View();
        }
        // Inicia controladores de linea de comida
        [HttpGet]
        public ActionResult LineaComida()
        {
            ViewBag.listaLineaComida = LineaComidaModel.ObtenerLineasComida();
            return View();
        }

        [HttpPost]
        public ActionResult LineaComidaAdd(LineaComidaModel model)
        {
            LineaComidaModel.AddDB(model);
            ViewBag.listaLineaComida = LineaComidaModel.ObtenerLineasComida();
            return View("LineaComida");
        }

        [HttpPost]
        public ActionResult LineaComidaEdit(LineaComidaModel model)
        {
            LineaComidaModel.EditDB(model);
            ViewBag.listaLineaComida = LineaComidaModel.ObtenerLineasComida();
            return View("LineaComida");
        }

        [HttpPost]
        public ActionResult LineaComidaDelete(LineaComidaModel model)
        {
            LineaComidaModel.DeletetDB(model);
            ViewBag.listaLineaComida = LineaComidaModel.ObtenerLineasComida();
            return View("LineaComida");
        }
        // Termina controladores de linea de comida
    }
}