using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConoceTe.Azure.Storage.Interfaces;
using ConoceTe.Azure.Storage.Services;
using ConoceTe.Identity.API.Context;
using ConoceTe.Identity.API.Helpers;
using ConoceTe.Identity.API.Middleware;
using ConoceTe.Identity.API.Services;
using ConoceTe.Identity.API.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConoceTe.Identity.API
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
            services.AddControllers();

            // Identity
            services.AddDbContext<SecurityContext>(options => 
                options.UseNpgsql(Configuration.GetConnectionString("Default"),
                x => x.MigrationsHistoryTable("__MigrationsHistory", SecurityContext.DEFAULT_SCHEMA)));

            IdentityHelper.ConfigureService(services);

            // Helpers
            AuthenticationHelper.ConfigureService(services, Configuration["JwtSecurityToken:Issuer"], Configuration["JwtSecurityToken:Audience"], Configuration["JwtSecurityToken:Key"]);
            CorsHelper.ConfigureService(services);
            SwaggerHelper.ConfigureService(services);

            // Settings
            services.Configure<EmailSettings>(Configuration.GetSection("Email"));
            services.Configure<ClientAppSettings>(Configuration.GetSection("ClientApp"));
            services.Configure<JwtSecurityTokenSettings>(Configuration.GetSection("JwtSecurityToken"));
            services.Configure<QRCodeSettings>(Configuration.GetSection("QRCode"));

            // Services
            services.AddTransient<IEmailService, EmailService>();

            // Azure
            // Azure Storage Services
            services.AddScoped<IBlobStorage>(s => new BlobStorage(Configuration["ConnectionStrings:AzureStorage"], Configuration["AzureStorage:ContainerName"], Configuration["AzureStorage:Url"]));
            services.AddScoped<IQueueStorage>(s => new QueueStorage(Configuration["ConnectionStrings:AzureStorage"]));

            // Data
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseErrorHandlingMiddleware();

            // Use WhiteList
            // app.UseWhiteListMiddleware(Configuration["AllowedIPs"]);

            app.UseRouting();

            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity Web API V1");
                //c.RoutePrefix = "";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
