using System;
using System.Collections.Generic;
using System.Text;

namespace Egress.Api.General.Entities.Dao.Dto.Acceso.Request
{
    public class GenerarTokenRequest
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}
