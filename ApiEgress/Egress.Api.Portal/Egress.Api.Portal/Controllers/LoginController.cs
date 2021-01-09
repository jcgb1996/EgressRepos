using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Egress.Api.Aplicacion.Contracts.Interfaces.Dto;
using Egress.Api.General.Entities.Dao.Dto.Acceso.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Egress.Api.Portal.Controllers
{
    [Route("Egress/api/[controller]/V1")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region Campos
        private readonly IvalidarAcceso _mapeoValidarAcceso;
        #endregion


        #region Constructores
        public LoginController(IvalidarAcceso mapeoValidarAcceso) //: base(logHandler)
        {
            //ControllerName = StrHandler.ComisionesController;
            _mapeoValidarAcceso = mapeoValidarAcceso ?? throw new ArgumentNullException(nameof(mapeoValidarAcceso));
        }
        #endregion

        // GET api/values
        [HttpPost("ValidaUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ValidaUsuarioResponse>> ValidaUsuario(string value)
        {
            return await Task.Run(() =>
            {
                var ValidaUsuario =  _mapeoValidarAcceso.ValidarUsuario(value);
                _mapeoValidarAcceso.Dispose();
                return ValidaUsuario;
            });
           
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
