﻿using Egress.Api.General.Entities.Dao.Dto.Acceso.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Egress.Api.Dominio.Contracts.Interfaces.Dto
{
    public interface IdValidarAcceso : IDisposable
    {
        ValidaUsuarioResponse ValidarUsuario(string Usuario);
    }
}
