using System;
using System.Web;

namespace WebEgress.Helper
{
    public class SessionHelper
    {
        #region Constantes PPM

        private const string SesionUsuario = "Usuario";

        #endregion      


        #region Escribir, leer y eliminar Sesion
        public static T LeeSesion<T>(string variable)
        {
            try
            {
                if (HttpContext.Current.Session != null)
                {
                    object valor = HttpContext.Current.Session[variable];
                    if (valor == null)
                        return default(T);
                    else
                        return ((T)valor);
                }
                else
                    return default(T);
            }
            catch (Exception)
            {
                return default(T);
            }
        }
        public static void EscribeSesion(string variable, object valor)
        {
            HttpContext.Current.Session[variable] = valor;
        }
        public static void EliminaSesion(string variable)
        {
            HttpContext.Current.Session.Remove(variable);
        }

        public static void EliminarTodasLasSesion()
        {
            HttpContext.Current.Session.Abandon();
        }





        #endregion

        #region Validar Sesion Usuario

        public static bool ValidarSesionActiva()
        {
            return Usuario != null;
        }

        #endregion

        #region Variables de sesion

        #region Sesion del usuario Logeado
        public static string Usuario
        {
            get
            {
                return LeeSesion<string>(SesionUsuario);
            }
            set
            {
                EscribeSesion(SesionUsuario, value);
            }
        }
        public static string ObtenerNombreSessionUsuario()
        {
            return SesionUsuario;
        }

        #endregion

        //
        // 

        #endregion
    }
}