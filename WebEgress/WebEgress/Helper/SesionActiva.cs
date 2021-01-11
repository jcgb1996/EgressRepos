using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebEgress.Helper
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class SesionActiva : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {





            if (!SessionHelper.ValidarSesionActiva())
            {
                SessionHelper.EliminarTodasLasSesion();

                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    //Mensajes Msj = TipoMensajes.GetTipoMensaje(EntidadesWebApi.Model.TipoMensaje.Session);
                    //Msj.Mensaje = "Sesion Expirada";
                    //filterContext.Result = new JsonResult() { Data = Msj };
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        area = "",
                        controller = "Home",
                        action = "Index"
                    }));
                }
            }

            base.OnActionExecuting(filterContext);

        }

    }
}