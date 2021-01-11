﻿using Egress.Api.General.Entities.Dao.Dto.Acceso.Request;
using Egress.Api.General.Entities.Dao.Dto.Acceso.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Egress.Api.Dominio.Contracts.Interfaces.Dto
{
    public interface IdJwtSeguridad: IDisposable
    {
        string ConsultarParametrosJwt(string Parametro);
        JwtTokenResponse GenerarValidarToken(GenerarTokenRequest generarTokenRequest);
    }
}
