using System;
using System.Collections.Generic;
using System.Text;

namespace Egress.Api.General.Entities.Dao.Dto.Acceso.Request
{
    public class RegistrarUsuarioResponse
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }

    }
}
