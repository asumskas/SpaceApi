using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpaceApi.Aplicacion.IGestor;
using SpaceApi.Aplicacion.Gestor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using SpaceApi.Core.Service;
using SpaceApi.Core.Interface;
using SateliteService = SpaceApi.Core.Service.SateliteService;
using System.Reflection;
using System.IO;

namespace SpaceApi
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Satelitesettings>(Configuration.GetSection(nameof(Satelitesettings)));
            services.AddControllers();
            ConfigureDependencyInjection(services);
            services.AddSingleton<ISatelitesettings>(d => d.GetRequiredService<IOptions<Satelitesettings>>().Value);

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API Space", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name }.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                swagger.IncludeXmlComments(xmlPath);
            });

            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapControllers();

            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Banelco");
            });









        }

        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddTransient< IGestorSpace, GestorSpace>();
            services.AddSingleton<ISateliteService , SateliteService>();

        }
    }
}
