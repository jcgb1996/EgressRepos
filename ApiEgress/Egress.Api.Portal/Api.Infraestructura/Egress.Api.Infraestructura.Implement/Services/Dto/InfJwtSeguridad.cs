using Egress.Api.Dominio.Contracts.Interfaces.Dto;
using Egress.Api.General.Entities.Dao.Dto.Acceso.Request;
using Egress.Api.General.Entities.Dao.Dto.Acceso.Response;
using Egress.Api.Infraestructura.Implement.Models;
using Egress.Api.Infraestructura.Implement.Services.General;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Egress.Api.Infraestructura.Implement.Services.Dto
{
    public class InfJwtSeguridad : IdJwtSeguridad
    {

        #region Variables
        ConsultarParametros consultarParametros;
        Usuario usuarioRegistro;
        private bool _disposed = false;
        #endregion

        #region Constructor
        public InfJwtSeguridad()
        {
            consultarParametros = new ConsultarParametros();
            usuarioRegistro = new Usuario();
        }

        #endregion

        #region Metodos

        public string ConsultarParametrosJwt(string Parametro)
        {

            return consultarParametros.ConsultarParametrosPorCodigo(Parametro);
        }


        public JwtTokenResponse GenerarValidarToken(GenerarTokenRequest generarTokenRequest)
        {
            JwtTokenResponse response = new JwtTokenResponse();

            JwtToken jwtToken = new JwtToken();
            if (!usuarioRegistro.ValidaUsuarioExistente(generarTokenRequest.Usuario))
            {

                response.response = new Api.General.Entities.Dao.Dto.Response()
                {
                    CodigoError = "200",
                    Mensaje = "Usuario no registrado para generar Token",
                    Value = "Error",
                    Exito = false,
                };
            }
            else
            {
                var Password = usuarioRegistro.ConsultarPasswordUsuario(generarTokenRequest.Usuario);
                var Datos = jwtToken.GenerarToken(generarTokenRequest.Usuario, Password);
                if (Datos.Exito)
                {
                    response.response = new Api.General.Entities.Dao.Dto.Response()
                    {
                        CodigoError = Datos.CodigoError,
                        Mensaje = Datos.Mensaje,
                        Value = Datos.Value,
                        Exito = Datos.Exito,
                    };
                    response.Token = Datos.Value;
                }
                else
                {
                    response.response = new Api.General.Entities.Dao.Dto.Response()
                    {
                        CodigoError = Datos.CodigoError,
                        Mensaje = Datos.Mensaje,
                        Value = Datos.Value,
                        Exito = Datos.Exito,
                    };
                    response.Token = Datos.Value;

                }
                
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

        ~InfJwtSeguridad()
        {
            Dispose(false);
        }
        #endregion


    }


}
