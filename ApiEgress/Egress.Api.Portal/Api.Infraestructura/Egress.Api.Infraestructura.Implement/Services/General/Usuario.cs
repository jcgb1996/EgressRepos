using Egress.Api.General.Entities.Dao.Dto;
using Egress.Api.General.Entities.Dao.Dto.Acceso.Request;
using Egress.Api.General.Entities.Dao.Dto.Acceso.Response;
using Egress.Api.Infraestructura.Implement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Egress.Api.Infraestructura.Implement.Services.General
{
    public class Usuario
    {
        private static BbEgressContext db;
        public Usuario()
        {
            db = new BbEgressContext();
        }
        public Response RegistrarUsuario(RegistrarUsuarioResponse registrarUsuarioResponse)
        {
            Response response;
            try
            {
                Aes256 aes256 = new Aes256();
                var Password = aes256.JwtEncriptarPassword(registrarUsuarioResponse.Password);
                //using (BbEgressContext db = new BbEgressContext())
                //{
                EgressUsuario egressUsuario = new EgressUsuario()
                {
                    Usuario = registrarUsuarioResponse.Usuario,
                    Password = Password,
                    Estado = "A",
                };
                db.EgressUsuario.Add(egressUsuario);

                DetEgressUsuario detEgressUsuario = new DetEgressUsuario()
                {
                    Apellidos = registrarUsuarioResponse.Apellidos,
                    Nombres = registrarUsuarioResponse.Nombres,
                    Correo = registrarUsuarioResponse.Correo,
                    Usuario = registrarUsuarioResponse.Usuario,
                };
                db.DetEgressUsuario.Add(detEgressUsuario);

                JwtEgress jwtEgress = new JwtEgress()
                {
                    Usuario = registrarUsuarioResponse.Usuario,
                    Token = "",

                };
                db.JwtEgress.Add(jwtEgress);

                db.SaveChanges();

                //}

                response = new Response() { CodigoError = "200", Mensaje = "Uusario registrado correctamente", Value = "ok", Exito = true, };

            }
            catch (Exception ex)
            {
                response = new Response() { CodigoError = "500", Mensaje = ex.Message, Value = "Error", Exito = false, };
            }
            return response;
        }

        public bool ValidaUsuarioExistente(string Usuario)
        {
            bool ExisteUsuario = false;
            //using (BbEgressContext db = new BbEgressContext())
            //{
            ExisteUsuario = db.EgressUsuario.Any(x => x.Usuario.ToLower().Equals(Usuario.ToLower()));
            //}

            return ExisteUsuario;
        }

        public string ConsultarPasswordUsuario(string Usuario)
        {
            string Passw0rd = string.Empty;
            //using (BbEgressContext db = new BbEgressContext())
            //{
            Passw0rd = db.EgressUsuario.First(x => x.Usuario.ToLower().Equals(Usuario.ToLower())).Password;
            //}
            return Passw0rd;
        }
    }
}
