using Egress.Api.General.Entities.Dao.Dto;
using Egress.Api.General.Entities.Dao.Dto.Acceso.Request;
using Egress.Api.General.Entities.Jwt.Dto;
using Egress.Api.Infraestructura.Implement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Egress.Api.Infraestructura.Implement.Services.General
{
    public class JwtToken
    {
        //PasswordJWT
        public Response GenerarToken(string Usuario, string Password)
        {
            Response response = new Response();
            try
            {
                ConsultarParametros consultarParametros = new ConsultarParametros();
                var Token = ObtenerTokenUsuario(Usuario);
                var KeyToken = consultarParametros.ConsultarParametrosPorCodigo("PasswordJWT");
                ValidarTokenHandler tokenHandler = new ValidarTokenHandler(Token, KeyToken);
                bool VerificaTokenValido = tokenHandler.Verify();
                if (!VerificaTokenValido)
                {
                    var TokeAc = ActualizarTokenUsuario(Usuario, Password);
                    response.CodigoError = "200";
                    response.Value = TokeAc;
                    response.Mensaje = "ok";
                    response.Exito = true;
                }
                else
                {
                    response.CodigoError = "200";
                    response.Value = Token;
                    response.Mensaje = "ok";
                    response.Exito = true;
                }
            }
            catch (Exception ex)
            {
                response.CodigoError = "500";
                response.Value = "Error";
                response.Mensaje = ex.Message;
                response.Exito = false;
            }
            
            return response;
        }

        private string ObtenerTokenUsuario(string Usuario)
        {
            string Token = string.Empty;
            using (BbEgressContext db = new BbEgressContext())
            {
                Token = db.JwtEgress.First(x => x.Usuario == Usuario).Token;
            }
            return Token;
        }


        private string GenerarTokenConTimepo(string Usuario, string Password, Auth auth)
        {
            ConsultarParametros consultarParametros = new ConsultarParametros();
            var Minutos = consultarParametros.ConsultarParametrosPorCodigo("TimerJWT");
            var DoublwMinutos = Convert.ToDouble(Minutos);
            var Token = auth.CreateJwt(DoublwMinutos, Usuario, Password);
            return Token;
        }

        private string ActualizarTokenUsuario(string Usuario, string Password)
        {
            Auth auth = new Auth();
            var Token = GenerarTokenConTimepo(Usuario, Password, auth);
            using (BbEgressContext db = new BbEgressContext())
            {
                JwtEgress jwtEgres = db.JwtEgress.Single(p => p.Usuario == Usuario);
                //SegJwtTokenEmpresa segJwtTokenEmpresa = db.SegJwtTokenEmpresa.Single(p => p.Username == user.Username && p.Password == user.pwd && p.Codigo == "correo");
                jwtEgres.Token = Token;
                db.SaveChanges();
            };
            return Token;
        }
    }
}
