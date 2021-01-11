using Egress.Api.Dominio.Contracts.Interfaces.Dto;
using Egress.Api.Infraestructura.Implement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Egress.Api.General.Entities.Dao.Dto.Acceso.Response;
using Egress.Api.General.Entities.Dao.Dto.Acceso.Request;
using Egress.Api.Infraestructura.Implement.Services.General;
using Egress.Api.General.Entities.Dao.Dto;

namespace Egress.Api.Infraestructura.Implement.Services.Dto
{
    public class InfValidarAcceso : IdValidarAcceso
    {
        #region Variables 
        private bool _disposed = false;
        private ValidaUsuarioResponse validaUsuarioResponse;
        private UsuarioRegistro usuarioRegistro;
        #endregion

        #region Constructor
        public InfValidarAcceso()
        {
            validaUsuarioResponse = new ValidaUsuarioResponse();
            usuarioRegistro = new UsuarioRegistro();
        }
        #endregion

        #region Metodos
        public ValidaUsuarioResponse ValidarUsuario(string Usuario)
        {
            bool ExisteUsuario = false;
            try
            {
                //using (BbEgressContext db = new BbEgressContext())
                //{
                //UsuarioRegistro usuarioRegistro = new UsuarioRegistro();
                ExisteUsuario = usuarioRegistro.ValidaUsuarioExistente(Usuario);
                if (ExisteUsuario)
                {
                    validaUsuarioResponse = new ValidaUsuarioResponse()
                    {
                        response = new Api.General.Entities.Dao.Dto.Response
                        {
                            CodigoError = "200",
                            Mensaje = "ok",
                        },
                        ExisteUsuario = ExisteUsuario,

                    };
                }
                else
                {
                    validaUsuarioResponse = new ValidaUsuarioResponse()
                    {
                        response = new Api.General.Entities.Dao.Dto.Response
                        {
                            CodigoError = "200",
                            Mensaje = "Usuario no registrado, por favor registrarse",
                        },
                        ExisteUsuario = ExisteUsuario,

                    };
                }
                    
                //}

            }
            catch (Exception ex)
            {

                validaUsuarioResponse = new ValidaUsuarioResponse()
                {
                    response = new Api.General.Entities.Dao.Dto.Response()
                    {
                        CodigoError = "500",
                        Mensaje = ex.Message != "" ? ex.Message : "Error a validar el usuario",
                    },
                    ExisteUsuario = ExisteUsuario,

                };
            }
            return validaUsuarioResponse;
        }

        public Response ValidarPassword(string Usuario, string Password)
        {
            Response response;
            Aes256 aes256 = new Aes256();
            try
            {
               
                string PasswordUser = usuarioRegistro.ConsultarPasswordUsuario(Usuario);
                if (Password.Equals(PasswordUser))
                {
                    response = new Response()
                    {
                        CodigoError = "200",
                        Exito = true,
                        Mensaje = "Contraseña correcta",
                        Value = "",
                    };
                }
                else
                {
                    response = new Response()
                    {
                        CodigoError = "200",
                        Exito = false,
                        Mensaje = "Contraseña incorrecta",
                        Value = "",
                    };
                }
            }
            catch (Exception ex)
            {
                response = new Response()
                {
                    CodigoError = "500",
                    Exito = false,
                    Mensaje = ex.Message,
                    Value = "",
                };
            }

            return response;
        }

        public Response RegistrarUsuario(RegistrarUsuarioResponse Usuario)
        {

            Response response;
            try
            {
                response = new Response();
                bool ExisteUsuario = usuarioRegistro.ValidaUsuarioExistente(Usuario.Usuario);
                if (!ExisteUsuario)
                {
                    response = usuarioRegistro.RegistrarUsuario(Usuario);
                }
                else
                {
                    response = new Response()
                    {
                        CodigoError="200",
                        Mensaje="Usuario ya registrado en el sistema",
                        Value="Error",
                        Exito = false,
                    };
                }
            }
            catch (Exception ex)
            {
                response = new Response()
                {
                    CodigoError = "500",
                    Mensaje = ex.Message,
                    Value = "Error",
                    Exito = false,
                };
            }
            return response;
        }


        #endregion


        #region IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                //IDValidarAcceso.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~InfValidarAcceso()
        {
            Dispose(false);
        }
        #endregion
    }
}
