using Egress.Aplicacion.Entities.Login.Dto.Request;
//using Egress.Aplicacion.Entities.Login.Dto.Response;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Threading.Tasks;
using System.Web.Configuration;
using Entidades = Egress.Aplicacion.Entities;

namespace Egress.Aplicacion.Services.Services.General
{
    public class Consultar
    {
        #region
        public const string ResourceToken = "/Egress/api/Login/V1/ValidaUsuario";
        public const string ResourceValidaPassword = "/Egress/api/Login/V1/ValidaPassword";
        public const string ResourceRegistroUsuario = "/Egress/api/Login/V1/RegistrarUsuario";
        #endregion

        public async Task<Entidades.Login.Dto.Response.ValidaUsuarioResponse> ValidaUsuario(string Usuario)
        {
            var UrlBase = WebConfigurationManager.AppSettings["UrlBase"].ToString(); //"http://localhost:41683";
            var Client = new RestClient(UrlBase);
            var _ValidaUsuarioResponse = new Entidades.Login.Dto.Response.ValidaUsuarioResponse();
            try
            {
                var Resource = ResourceToken;//"/api/portal/Auth/GenerarTokenCorreo";
                var requestRshp = new RestRequest(Resource, method: Method.GET);
                requestRshp.AddHeader("content-type", "application/json");

                requestRshp.AddQueryParameter("value", Usuario);
                var Consulta = await Client.ExecuteTaskAsync(requestRshp);

                if (!string.IsNullOrEmpty(Consulta.ErrorMessage) && Consulta.ErrorException != null)
                {
                    _ValidaUsuarioResponse = new Entidades.Login.Dto.Response.ValidaUsuarioResponse()
                    {
                        Response = new Entidades.Response()
                        {
                            CodigoError = "500",
                            Exito = false,
                            Mensaje = Consulta.ErrorMessage ?? Consulta.ErrorException.Message,
                            Value = "Error",
                        },
                        ExisteUsuario = false,

                    };
                }
                else
                {
                    JsonDeserializer Deserial = new JsonDeserializer();
                    _ValidaUsuarioResponse = Deserial.Deserialize<Entidades.Login.Dto.Response.ValidaUsuarioResponse>(Consulta);
                }


            }
            catch (Exception ex)
            {

                _ValidaUsuarioResponse = new Entidades.Login.Dto.Response.ValidaUsuarioResponse()
                {

                    Response = new Entities.Response()
                    {
                        CodigoError = "500",
                        Exito = false,
                        Mensaje = ex.Message,
                    }
                };
            }


            return _ValidaUsuarioResponse;
        }

        public  async Task<Entidades.Response> ValidarPassword(string Usuario, string Password)
        {
            var UrlBase = WebConfigurationManager.AppSettings["UrlBase"].ToString(); //"http://localhost:41683";
            var Client = new RestClient(UrlBase);
            var Registro = new Entidades.Response();
            Aes256 aes256 = new Aes256();
            try
            {
                var Resource = ResourceValidaPassword;//"/api/portal/Auth/GenerarTokenCorreo";
                var requestRshp = new RestRequest(Resource, method: Method.GET);
                requestRshp.AddHeader("content-type", "application/json");
                requestRshp.AddQueryParameter("Usuario", Usuario);
                var PasswordEncrypt =  aes256.JwtEncriptarPassword(Password);
                requestRshp.AddQueryParameter("Password", PasswordEncrypt);

                var Consulta = await Client.ExecuteTaskAsync(requestRshp);
                if (!string.IsNullOrEmpty(Consulta.ErrorMessage) && Consulta.ErrorException != null)
                {


                    Registro.CodigoError = "500";
                    Registro.Exito = false;
                    Registro.Mensaje = Consulta.ErrorMessage ?? Consulta.ErrorException.Message;
                    Registro.Value = "Error";


                }
                else
                {
                    JsonDeserializer Deserial = new JsonDeserializer();
                    Registro = Deserial.Deserialize<Entidades.Response>(Consulta);
                }
            }
            catch (Exception ex)
            {
                Registro = new Entidades.Response()
                {
                    CodigoError = "500",
                    Mensaje = ex.Message,
                    Value = "Error",
                    Exito = false,
                };
            }

            return Registro;
        }

        public async Task<Entidades.Response> RegistrarUsuario(RegistrarUsuarioRequest Usuario)
        {
            var UrlBase = WebConfigurationManager.AppSettings["UrlBase"].ToString(); //"http://localhost:41683";
            var Client = new RestClient(UrlBase);
            var Registro = new Entidades.Response();
            try
            {
                var Resource = ResourceRegistroUsuario;//"/api/portal/Auth/GenerarTokenCorreo";
                var requestRshp = new RestRequest(Resource, method: Method.POST);
                requestRshp.AddHeader("content-type", "application/json");
                requestRshp.AddJsonBody(Usuario);
                var Consulta = await Client.ExecuteTaskAsync(requestRshp);

                if (!string.IsNullOrEmpty(Consulta.ErrorMessage) && Consulta.ErrorException != null)
                {


                    Registro.CodigoError = "500";
                    Registro.Exito = false;
                    Registro.Mensaje = Consulta.ErrorMessage ?? Consulta.ErrorException.Message;
                    Registro.Value = "Error";


                }
                else
                {
                    JsonDeserializer Deserial = new JsonDeserializer();
                    Registro = Deserial.Deserialize<Entidades.Response>(Consulta);
                }


            }
            catch (Exception ex)
            {

                Registro = new Entidades.Response()
                {
                    CodigoError = "500",
                    Mensaje = ex.Message,
                    Value = "Error",
                    Exito = false,
                };
            }

            return Registro;
        }
    }
}
