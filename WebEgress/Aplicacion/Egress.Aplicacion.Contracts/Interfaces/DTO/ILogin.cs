
using Egress.Aplicacion.Entities;
using Egress.Aplicacion.Entities.Login.Dto.Request;
using Egress.Aplicacion.Entities.Login.Dto.Response;
using System.Threading.Tasks;

namespace Egress.Aplicacion.Contracts.Interfaces.DTO
{
    public interface ILogin
    {
        Task<ValidaUsuarioResponse> ValidarUsuario(string Usuario);
        Task<Response> ValidarUsuario(RegistrarUsuarioRequest Usuario);
        Task<Response> ValidaPassword(string Usuario, string Password);
    }
}
