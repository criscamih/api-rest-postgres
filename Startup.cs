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
            services.AddCors();
            services.AddControllers();
            services.AddDbContext<DataAccessContext>(options => options.UseNpgsql(Configuration.GetConnectionString("postgresConnectionString")));
            services.AddScoped<IDataAccessProvider, DataAccessProvider>();
            services.AddScoped<IDataAccessArea, DataAccessArea>();
            services.AddScoped<IDataAccessEmpleado, DataAccessEmpleado>();
            services.AddScoped<IDataAccessEstado, DataAccessEstado>();
            services.AddScoped<IDataAccessProducto, DataAccessProducto>();
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
