using Egress.Api.General.Entities.Dao.Dto;
using Egress.Api.General.Entities.Dao.Dto.Acceso.Request;
using Egress.Api.General.Entities.Dao.Dto.Acceso.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Egress.Api.Aplicacion.Contracts.Interfaces.Dto
{
    public interface IvalidarAcceso : IDisposable
    {
        ValidaUsuarioResponse ValidarUsuario(string Usuario);
        Response RegistrarUsuario(RegistrarUsuarioResponse Usuario);
        Response ValidarPassword(string Usuario, string Password);
    }
}
