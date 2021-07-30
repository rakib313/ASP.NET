using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Add static files middleware
            app.UseStaticFiles();
            
            // looks for index action method in home controller
            app.UseMvcWithDefaultRoute();

            // At this point we have no home controller so we see error 404 - Not Found
            // app.Run(async (context) =>
            // {
            //     await context.Response.WriteAsync("Hello World");
            // });
        }
    }
}
