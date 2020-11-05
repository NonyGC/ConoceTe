using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ConoceTe.Citas.API.Helpers
{
    public class SwaggerHelper
    {
        public static void ConfigureService(IServiceCollection service)
        {
            service.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("JWT", new OpenApiSecurityScheme
                {
                    Description = "Encabezado de autorización estándar utilizando el esquema Bearer. Ejemplo: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ConoceTe - Citas API",
                    Version = "v1",
                    Description = "Microservicio de Citas Psicológicas",
                    Contact = new OpenApiContact
                    {
                        Name = "Giraldo Castillo, Nony",
                        //Url = new Uri("https://github.com/shammelburg/CoreIdentity")
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
