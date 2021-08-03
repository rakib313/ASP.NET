using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmployeeManagement
{
    //Two steps to setup MVC in ASP.NET Core Application in dotnetcore3 or earler
    //Step 1 : In ConfigureServices() method of the Startup class in Startup.cs file which adds the required MVC services to the dependency injection container.
    //Step 2 : In the Configure() method, add UseMvcWithDefaultRoute() midddleware to our application's request processing pipeline.
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //EnbleEntpointRount is new and not using it now
            services.AddControllers(options => options.EnableEndpointRouting = false);
            
            // Add XML serializer formatter added to be able to return XML format
            services.AddMvc().AddXmlDataContractSerializerFormatters();

            // Created only 1 time per application and that single instance is used throughout the lifetime
            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Add static files middleware
            app.UseStaticFiles();
            
            // Adds MVC support with the default route configured
            //app.UseMvcWithDefaultRoute();

            // Configure route: =Hone and =Index configures route when using root url
            app.UseMvc(routes => {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            // At this point we have no home controller so we see error 404 - Not Found
            // app.Run(async (context) =>
            // {
            //     await context.Response.WriteAsync("Hello World");
            // });
        }
    }
}
