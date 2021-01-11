using System;
using System.Collections.Generic;

namespace Egress.Api.Infraestructura.Implement.Models
{
    public partial class EgressUsuario
    {
        public EgressUsuario()
        {
            DetEgressUsuario = new HashSet<DetEgressUsuario>();
            JwtEgress = new HashSet<JwtEgress>();
        }

        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<DetEgressUsuario> DetEgressUsuario { get; set; }
        public virtual ICollection<JwtEgress> JwtEgress { get; set; }
    }
}
