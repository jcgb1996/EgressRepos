using Egress.Api.Infraestructura.Implement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Egress.Api.Infraestructura.Implement.Services.General
{
    public class ConsultarParametros
    {
        public string ConsultarParametrosPorCodigo(string Parametro)
        {

            string ParametroResult = string.Empty;
            try
            {
                using (BbEgressContext db = new BbEgressContext())
                {
                    ParametroResult = db.Parametros.First(x => x.Codigo.Equals(Parametro)).Valor;
                }
            }
            catch (Exception ex)
            {

            }
           

            return ParametroResult;
        }
    }
}
