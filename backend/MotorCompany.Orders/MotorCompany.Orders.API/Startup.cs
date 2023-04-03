using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MediatR;
using MotorCompany.Orders.Datastore.SQLServer;
using Microsoft.EntityFrameworkCore;
using MotorCompany.Orders.API.Utility;
using MotorCompany.Orders.Core.Commands;
using System.Reflection;
using MotorCompany.Orders.Core.Utility;

namespace MotorCompany.Orders.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                var swaggerInfo = SwaggerInfo.Create();
                c.SwaggerDoc(swaggerInfo.Version, new OpenApiInfo
                {
                    Title = swaggerInfo.Title, 
                    Version = swaggerInfo.Version
                });
            });

            services.AddCors();

            services.AddMediatR(typeof(Startup));
            services.AddMediatR(typeof(CreateOrderCommand).GetTypeInfo().Assembly);

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<OrderDbContext>(opt => 
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddLogging();
            services.AddTransient<IApiConfiguration, ApiConfiguration>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiConfiguration apiConfig)
        {                     
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                var swaggerInfo = SwaggerInfo.Create();
                c.SwaggerEndpoint("/swagger/v1/swagger.json", swaggerInfo.Name);
                c.RoutePrefix = string.Empty;
            });

            app.UseCors(
                options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );

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

            if (Configuration.GetValue<bool>("RunMigrationsOnStartup"))
            {
                apiConfig.MigrateDatabase();
            }
        }
    }
}