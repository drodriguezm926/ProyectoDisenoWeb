using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFOOD.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public ActionResult Default()
        {
            return View();
        }
    }
}