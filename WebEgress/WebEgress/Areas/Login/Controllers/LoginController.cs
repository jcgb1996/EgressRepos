using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEgress.Areas.Login.Controllers
{
    public class LoginController : Controller
    {
       

        // POST: Login/Login/Create
        [HttpPost]
        public ActionResult ValidaUsuario(string Usuario)
        {
            try
            {   
                return PartialView("ContraseniaPartial");
            }
            catch
            {
                return PartialView("ContraseniaPartial");
            }
        }
        
       
    }
}
