using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
// using Microsoft.AspNetCore.Http
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmployeeManagement
{
    //Two steps to setup MVC in ASP.NET Core Application in dotnetcore3 or earler
    //Step 1 : In ConfigureServices() method of the Startup class in Startup.cs file which adds the required MVC services to the dependency injection container.
    //Step 2 : In the Configure() method, add UseMvcWithDefaultRoute() midddleware to our application's request processing pipeline.
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));

            // The following two services are equivalent to calling AddMvc(), visit https://docs.microsoft.com/en-us/aspnet/core/migration/22-to-30?view=aspnetcore-2.2&tabs=visual-studio#mvc-service-registration
            services.AddControllersWithViews();
            services.AddRazorPages();
            
            // Creates one every time
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            
            // Adds MVC support with the default route configured
            //app.UseMvcWithDefaultRoute();

            
            // Configure route: =Hone and =Index configures route when using root url
            // app.UseMvc(routes => {
            //     routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            // });
            
            // Attribute routing
            //app.UseMvc();

            // The above code is for dotnet 2.2 and older version 

            // Add static files middleware
            app.UseStaticFiles();

            app.UseRouting();

            // Authorization should be placed here


            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{Controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapRazorPages();
            });

            // At this point we have no home controller so we see error 404 - Not Found
            // app.Run(async (context) =>
            // {
            //     await context.Response.WriteAsync("Hello World");
            // });
        }
    }
}
