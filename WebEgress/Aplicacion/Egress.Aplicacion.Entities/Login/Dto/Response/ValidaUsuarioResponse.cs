using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egress.Aplicacion.Entities.Login.Dto.Response
{
    public class ValidaUsuarioResponse
    {
        public Entities.Response Response { get; set; }
        public bool ExisteUsuario { get; set; }
    }
}
