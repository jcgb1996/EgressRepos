using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Egress.Api.Aplicacion.Contracts.Interfaces.Dto;
using Egress.Api.General.Entities.Dao.Dto.Acceso.Request;
using Egress.Api.General.Entities.Dao.Dto.Acceso.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Egress.Api.Portal.Controllers
{
    [Route("api/portal/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        #region Campos
        private readonly IJwtSeguridad _IJwtSeguridad;
        //private readonly IRegistroSwTrama _IRegistroSwTrama;
        #endregion


        #region Constructores


        public AuthController(IJwtSeguridad IjwtSeguridad)
        {
            _IJwtSeguridad = IjwtSeguridad ?? throw new ArgumentNullException(nameof(IjwtSeguridad));

        }
        #endregion

        [HttpPost("GenerarToken")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JwtTokenResponse>> GenerarToken([FromBody] GenerarTokenRequest user)
        {
            return await Task.Run(() =>
            {
                var DatosToken = _IJwtSeguridad.GenerarValidarToken(user);
                _IJwtSeguridad.Dispose();
                 return DatosToken;
            });
            //return Unauthorized("Creendenciais Inválidas!");

        }

    }
}