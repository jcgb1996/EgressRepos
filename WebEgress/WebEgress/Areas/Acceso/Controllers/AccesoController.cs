
using Egress.Aplicacion.Contracts.Interfaces.DTO;
using System.Web.Mvc;
//using WebEgress.Aplicacion.Iegress;
using Unity;

namespace WebEgress.Areas.Acceso.Controllers
{
    public class AccesoController : Controller
    {

        [HttpPost]
        public PartialViewResult ValidaUsuario(string Usuario)
        {
            ILogin Repositorio = UnityConfig.Container.Resolve<ILogin>();
            Repositorio.ValidarUsuario(Usuario);
            return PartialView("_ContraseniaPartial");
        }

        [HttpPost]
        public ActionResult ValidaPassword(string Password)
        {
            return View("_UserRegistroPartial");
            // return PartialView("_UserRegistroPartial");
        }

        public PartialViewResult ViewLoginRegistro()
        {
            return PartialView("_UserRegistroPartial");
        }

    }
}
