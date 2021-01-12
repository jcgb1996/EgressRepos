using System;
using System.Collections.Generic;
using System.Text;

namespace Egress.Api.General.Entities.Dao.Dto.Acceso.Response
{
    public class JwtTokenResponse
    {
        public Dto.Response response { get; set; }
       // public int Id { get; set; }
        public string Token { get; set; }

    }
}
