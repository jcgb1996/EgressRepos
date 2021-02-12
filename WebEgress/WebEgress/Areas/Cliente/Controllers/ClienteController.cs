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

        public ActionResult IndexValidaSession()
        {
            // string Usuario = formCollection["TxtUserFrm"];
            return View("Index");
        }

        //public RedirectToRouteResult IndexReturn()
        //{
        //    return RedirectToAction("Index", "Cliente");
        //
        //}


        public RedirectToRouteResult CerrarSesion()
        {
            SessionHelper.EliminarTodasLasSesion();
            return RedirectToAction("../../Home", "Index");

        }
    }
}
