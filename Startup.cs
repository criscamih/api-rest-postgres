using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using api_stock.DataAccess;
using Microsoft.EntityFrameworkCore;
using api_stock.Providers;
using api_stock.Providers.Interfaces;
using api_stock.common.interfaces;
using api_stock.Models;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.OpenApi.Models;

namespace api_stock
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
            //---para publicar en docker------
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            services.AddDbContext<DataAccessContext>(options => options.UseNpgsql(connectionString));
            //---para depuración en local---
            // services.AddDbContext<DataAccessContext>(options => options.UseNpgsql(Configuration.GetConnectionString("postgresConnectionString")));
            services.AddCors();
            services.AddControllers();
            services.AddScoped<IDetalleInventario, DetalleInventario>();
            services.AddScoped<IDataAccessRepository<InventarioModel>,DataAccessInventario>();
            services.AddScoped<IDataAccessRepository<AreaModel>,DataAccessArea>();
            services.AddScoped<IDataAccessRepository<EmpleadoModel>,DataAccessEmpleado>();
            services.AddScoped<IDataAccessRepository<EstadoModel>,DataAccessEstado>();
            services.AddScoped<IDataAccessRepository<ProductoModel>,DataAccessProducto>();
            services.AddScoped<IDataAccessRepository<ProveedorModel>,DataAccessProveedor>();
            services.AddScoped<IDataAccessRepository<TipoProductoModel>,DataAccessTP>();

            services.AddSwaggerGen( c => {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Agencia API-Rest", Version="v1"});
            });

            services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme)
            .AddCertificate();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>{
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Values API V1");
            });
            app.UseCors(builder => {
               builder
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
