using Egress.Api.Aplicacion.Contracts.Interfaces.Dto;
using Egress.Api.Dominio.Contracts.Interfaces.Dto;
using Egress.Api.General.Entities.Dao.Dto.Acceso.Request;
using Egress.Api.General.Entities.Dao.Dto.Acceso.Response;
using Egress.Api.Infraestructura.Implement.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Egress.Api.Aplicacion.Implement.Services.Dto
{
    public class JwtSeguridad : IJwtSeguridad
    {
        #region Variables
        private bool _disposed = false;
        IdJwtSeguridad _IDValidarAcceso = new InfJwtSeguridad();
        #endregion

        #region Metodos
        public string ConsultarParametrosJwt(string Parametro)
        {
            var Result = _IDValidarAcceso.ConsultarParametrosJwt(Parametro);
            _IDValidarAcceso.Dispose();
            return Result;
        }

        public JwtTokenResponse GenerarValidarToken(GenerarTokenRequest generarTokenRequest)
        {

             var Result = _IDValidarAcceso.GenerarValidarToken(generarTokenRequest);
            _IDValidarAcceso.Dispose();
            return Result;

        }

        #endregion




        #region IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                //_IDValidarAcceso.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~JwtSeguridad()
        {
            Dispose(false);
        }
        #endregion
    }
}
