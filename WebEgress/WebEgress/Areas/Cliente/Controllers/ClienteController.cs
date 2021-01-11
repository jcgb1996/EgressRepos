using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEgress.Helper;

namespace WebEgress.Areas.Cliente.Controllers
{
    [SesionActiva]
    public class ClienteController : Controller
    {
        public ActionResult Index(FormCollection formCollection)
        {
            string Usuario = formCollection["TxtUserFrm"];
            return View();
        }
        
    }
}
