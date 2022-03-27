using Infrastructure.HttpClients;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Polly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace WebAPI
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
            // MediatR *Referencia a Dependencia
            var assembly = AppDomain.CurrentDomain.Load("Application");
            services.AddMediatR(assembly);

            // Conexion DB
            services.AddDbContext<ApplicationContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("ACMEDB")));

            services.AddControllers();

            // Swagger
            AddSwagger(services);

            // Servicio de empresa ACME para envio de emails y sms
            // Politica de retry como patron de resiliencia
            var acmeClientSettings = new AcmeClientSettings();
            Configuration.GetSection("AcmeClientSettings").Bind(acmeClientSettings);
            services.AddSingleton(acmeClientSettings);
            services.AddHttpClient<IAcmeClient, AcmeClient>()
                .AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(new[]
                 {
                  TimeSpan.FromSeconds(2),
                  TimeSpan.FromSeconds(6),
                  TimeSpan.FromSeconds(10)
                 }));

        }

        // Swagger Middleware
        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"ACME API",
                    Version = "v1",
                    Description = "API para gestion de inventario",
                    Contact = new OpenApiContact
                    {
                        Name = "ACME Company",
                        Email = string.Empty,
                        Url = new Uri("https://acme.com/"),
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ACME API V1");
                c.RoutePrefix = "docs";
            });
        }
    }
}
