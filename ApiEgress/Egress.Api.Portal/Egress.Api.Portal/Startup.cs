
using System.Text;
using Egress.Api.Aplicacion.Contracts.Interfaces.Dto;
using Egress.Api.Aplicacion.Implement.Services.Dto;
using Egress.Api.General.Entities.Jwt.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Egress.Api.Portal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            IJwtSeguridad _IJwtSeguridad = new JwtSeguridad();
            var DatosJwtParametros = _IJwtSeguridad.ConsultarParametrosJwt("PasswordJWT");
            var key = Encoding.UTF8.GetBytes(DatosJwtParametros);

            Auth auth = new Auth(key);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => auth.ValidateJwt(options));

            services.AddAuthorization(auth => auth
                .AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser().Build())
            );

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Impulsa API",
                    Description = "API Web de Portal Impulsa",
                    Version = "v1",
                    Contact = new OpenApiContact()
                    {
                        Name = "Soporte",
                        Email = "soporte@Impulsa.com"
                    }
                });
            });

            services.AddTransient<IvalidarAcceso, ValidarAcceso>();
            services.AddTransient<IJwtSeguridad, JwtSeguridad>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Impulsa API V1");
            });
        }
    }
}
