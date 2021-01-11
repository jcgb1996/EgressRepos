using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egress.Aplicacion.Entities
{
    public class Response
    {
        public string CodigoError { get; set; }
        public string Mensaje { get; set; }
        public string Value { get; set; }
        public bool Exito { get; set; } 
    }
}
