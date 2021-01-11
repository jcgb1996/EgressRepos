using System;
using System.Collections.Generic;

namespace Egress.Api.Infraestructura.Implement.Models
{
    public partial class JwtEgress
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Token { get; set; }

        public virtual EgressUsuario UsuarioNavigation { get; set; }
    }
}
