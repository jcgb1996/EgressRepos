using Egress.Api.Dominio.Contracts.Interfaces.Dto;
using Egress.Api.Infraestructura.Implement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Egress.Api.General.Entities.Dao.Dto.Acceso.Response;

namespace Egress.Api.Infraestructura.Implement.Services.Dto
{
    public class InfValidarAcceso : IdValidarAcceso
    {
        private bool _disposed = false;
        public ValidaUsuarioResponse ValidarUsuario(string Usuario)
        {
            bool ExisteUsuario = false;
            ValidaUsuarioResponse validaUsuarioResponse;
            try
            {
                using (BbEgressContext db = new BbEgressContext())
                {
                    ExisteUsuario = db.EgressUsuario.Any(x => x.Usuario == Usuario && x.Estado == "A");
                    validaUsuarioResponse = new ValidaUsuarioResponse()
                    {
                        response = new General.Entities.Dao.Dto.Response
                        {
                            CodigoError = "200",
                            Mensaje = "Existo",
                        },
                        ExisteUsuario = ExisteUsuario,

                    };
                }

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
                    ExisteUsuario = ExisteUsuario,

                };
            }
            return validaUsuarioResponse;
        }

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
