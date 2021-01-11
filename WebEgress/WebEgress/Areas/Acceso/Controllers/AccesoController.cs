
using Egress.Aplicacion.Contracts.Interfaces.DTO;
using Egress.Aplicacion.Entities.Login.Dto.Request;
using System.Threading.Tasks;
using System.Web.Mvc;
//using WebEgress.Aplicacion.Iegress;
using Unity;
using WebEgress.Helper;

namespace WebEgress.Areas.Acceso.Controllers
{
    public class AccesoController : Controller
    {

        [HttpPost]
        public async Task<JsonResult> ValidaUsuario(string Usuario)
        {
            return await Task.Run(async () =>
            {
                ILogin Repositorio = UnityConfig.Container.Resolve<ILogin>();
                var Result = await Repositorio.ValidarUsuario(Usuario);
                return Json(Result);
            });

        }

        [HttpPost]
        public async Task<JsonResult> ValidaPassword(string Usuario, string Password)
        {
            //var Datos = await Task.Run(async () =>
            //{
            ILogin Repositorio = UnityConfig.Container.Resolve<ILogin>();
            var Result = await Repositorio.ValidaPassword(Usuario, Password);
            //return Result;
            //});

            if (Result.Exito)
            {
                SessionHelper.Usuario = Usuario;
            }

            return Json(Result);
        }


        [HttpGet]
        public async Task<ActionResult> CargarViewPassword(string Usuario)
        {
            return await Task.Run(() =>
            {
                return PartialView("_ContraseniaPartial", Usuario);
            });

        }



        [HttpPost]
        public async Task<JsonResult> RegistrarUsuario(RegistrarUsuarioRequest Usuario)
        {
            return await Task.Run(async () =>
            {
                ILogin Repositorio = UnityConfig.Container.Resolve<ILogin>();
                var Result = await Repositorio.ValidarUsuario(Usuario);
                return Json(Result);
            });

        }


        //[HttpPost]
        //public ActionResult ValidaPassword(string Password)
        //{
        //    return View("_UserRegistroPartial");
        //    // return PartialView("_UserRegistroPartial");
        //}

        public PartialViewResult ViewLoginRegistro()
        {
            return PartialView("_UserRegistroPartial");
        }

    }
}
