﻿using Egress.Api.Aplicacion.Contracts.Interfaces.Dto;
using Egress.Api.Dominio.Contracts.Interfaces.Dto;
using Egress.Api.General.Entities.Dao.Dto;
using Egress.Api.General.Entities.Dao.Dto.Acceso.Request;
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

        #region Metodos

        public ValidaUsuarioResponse ValidarUsuario(string Usuario)
        {
            var validaUsuarioResponse = _IDValidarAcceso.ValidarUsuario(Usuario);
            _IDValidarAcceso.Dispose();
            return validaUsuarioResponse;
        }

        public Response ValidarPassword(string Usuario, string Password)
        {
            var validaUsuarioResponse = _IDValidarAcceso.ValidarPassword(Usuario,Password);
            _IDValidarAcceso.Dispose();
            return validaUsuarioResponse;
        }

        public Response RegistrarUsuario(RegistrarUsuarioResponse Usuario)
        {
            var validaUsuarioResponse = _IDValidarAcceso.RegistrarUsuario(Usuario);
            _IDValidarAcceso.Dispose();
            return validaUsuarioResponse;
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

        ~ValidarAcceso()
        {
            Dispose(false);
        }
        #endregion
    }
}
