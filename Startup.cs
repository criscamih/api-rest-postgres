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
            // var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            // services.AddDbContext<DataAccessContext>(options => options.UseNpgsql(connectionString));
            services.AddDbContext<DataAccessContext>(options => options.UseNpgsql(Configuration.GetConnectionString("postgresConnectionString")));
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

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
