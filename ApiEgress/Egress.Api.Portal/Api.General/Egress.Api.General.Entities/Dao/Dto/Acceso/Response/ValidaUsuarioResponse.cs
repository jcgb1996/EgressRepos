using System;
using System.Collections.Generic;
using System.Text;
using Egress.Api.General.Entities.Dao.Dto;

namespace Egress.Api.General.Entities.Dao.Dto.Acceso.Response
{
    public class ValidaUsuarioResponse
    {
        public Dto.Response response { get; set; }
        public bool ExisteUsuario { get; set; }
    }
}
