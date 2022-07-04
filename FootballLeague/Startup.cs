using FootballLeague.Common.CustomMiddlewares.NewFolder;
using FootballLeague.Data;
using FootballLeague.IoCContainers.SimpleInjectorBootstraper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SimpleInjector;
using System;
using System.IO;

namespace FootballLeague
{
    public class Startup
    {
        private Container container = new Container();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FootballLeague", Version = "v1" });

                var filePath = Path.Combine(AppContext.BaseDirectory, "FootballLeague.xml");
                c.IncludeXmlComments(filePath);
            });

            services.AddSimpleInjector(container, options =>
            {
                options.AddAspNetCore()
                   .AddControllerActivation();
            });

            container.RegisterInstance(this.Configuration);

            IoCContainerBootstrap.InitializeSimpleInjector(container);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ApplicationServices.UseSimpleInjector(container);

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FootballLeague v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(
               endpoints =>
               {
                   endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                   endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
               });

            container.Verify();
        }
    }
}
