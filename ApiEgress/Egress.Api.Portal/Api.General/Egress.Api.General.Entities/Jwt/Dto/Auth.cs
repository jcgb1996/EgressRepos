using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

namespace Egress.Api.General.Entities.Jwt.Dto
{
    public class Auth
    {
        private static byte[] key; /* = Encoding.UTF8.GetBytes("waydatasolution@portal5");*/
        public Auth()
        {

        }
        public Auth(byte[] Key)
        {
            key = Key;
        }

        public void ValidateJwt(JwtBearerOptions options)
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(key != null ? key : Encoding.UTF8.GetBytes("waydatasolution@portal5"))
            };
        }

        public string CreateJwt(double minutos, string user, string pwd)
        {

            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("Username", user),
                new Claim("pwd", pwd),
            };

            var tokeOptions = new JwtSecurityToken(
                claims: _Claims,
                expires: DateTime.UtcNow.AddMinutes(minutos),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }
    }
}
