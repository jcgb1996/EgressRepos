using System;
using System.Collections.Generic;

namespace Egress.Api.Infraestructura.Implement.Models
{
    public partial class EgressDetUsuario
    {
        public string Usuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Passwors { get; set; }

        public virtual EgressUsuario UsuarioNavigation { get; set; }
    }
}
