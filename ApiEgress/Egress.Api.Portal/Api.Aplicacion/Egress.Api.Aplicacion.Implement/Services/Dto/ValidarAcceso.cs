using Egress.Api.Aplicacion.Contracts.Interfaces.Dto;
using Egress.Api.Dominio.Contracts.Interfaces.Dto;
using Egress.Api.General.Entities.Dao.Dto.Acceso.Response;
using Egress.Api.Infraestructura.Implement.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Egress.Api.Aplicacion.Implement.Services.Dto
{
    public class ValidarAcceso : IvalidarAcceso
    {
        private bool _disposed = false;
        IdValidarAcceso _IDValidarAcceso = new InfValidarAcceso();

        public ValidaUsuarioResponse ValidarUsuario(string Usuario)
        {
            ValidaUsuarioResponse validaUsuarioResponse;
            try
            {
                validaUsuarioResponse = _IDValidarAcceso.ValidarUsuario(Usuario);
                _IDValidarAcceso.Dispose();
            }
            catch (Exception ex)
            {
                validaUsuarioResponse = new ValidaUsuarioResponse()
                {
                    response = new General.Entities.Dao.Dto.Response()
                    {
                        CodigoError = "500",
                        Mensaje = ex.Message != "" ? ex.Message : "Error a validar el usuario",
                    },
                    ExisteUsuario = false,
                };
            }
            //IDValidarAcceso _IDValidarAcceso = new InfValidarAcceso();
            
            return validaUsuarioResponse;
        }

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


        ~ValidarAcceso()
        {
            Dispose(false);
        }
        #endregion
    }
}
