using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Egress.Api.General.Entities.Jwt.Dto
{
    public class ValidarTokenHandler : DelegatingHandler
    {
        private readonly string _jwt;
        private readonly byte[] _key;
        //private static readonly byte[] key = Encoding.UTF8.GetBytes("waydatasolution@portal5");
        public ValidarTokenHandler(string token, string key)
        {
            _jwt = token;
            _key = Encoding.UTF8.GetBytes(key);
        }

        public string TenantId
        {
            get
            {
                return new JwtSecurityToken(_jwt).Claims.FirstOrDefault(x => x.Type == "tid")?.Value;
            }
        }

        public bool Verify()
        {
            var validationParameter = new TokenValidationParameters()
            {
                RequireSignedTokens = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(_key)
            };

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var lala = handler.ValidateToken(_jwt, validationParameter, out var token);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
