using Egress.Aplicacion.Contracts.Interfaces.DTO;
using Egress.Aplicacion.Entities;
using Egress.Aplicacion.Entities.Login.Dto.Request;
using Egress.Aplicacion.Entities.Login.Dto.Response;
using Egress.Aplicacion.Services.Services.General;
using System.Threading.Tasks;

namespace Egress.Aplicacion.Services.Services.DTO
{
    public class LoginServices : ILogin
    {
        public async Task<ValidaUsuarioResponse> ValidarUsuario(string Usuario)
        {
            Consultar consultar = new Consultar();
            return await consultar.ValidaUsuario(Usuario);

        }

        public async  Task<Response> ValidarUsuario(RegistrarUsuarioRequest Usuario)
        {
            Consultar consultar = new Consultar();
            return await consultar.RegistrarUsuario(Usuario);
        }

        public async Task<Response> ValidaPassword(string Usuario, string Password)
        {
            Consultar consultar = new Consultar();
            return await consultar.ValidarPassword(Usuario, Password);
        }
    }
}
