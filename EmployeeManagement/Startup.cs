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
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions();
                // how many lines of code to include before and after the line of code that caused the exception
                developerExceptionPageOptions.SourceCodeLineCount = 10;
                app.UseDeveloperExceptionPage(developerExceptionPageOptions);
            }
            // else serve User Friendly Error Page with Application Support Contact Info
            else if (env.IsStaging() || env.IsProduction() || env.IsEnvironment("UAT"))
            {
                app.UseExceptionHandler("/Error");
            }
            
            // Serve default document
            app.UseFileServer();

            // Add static files middleware
            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                throw new Exception("Some error processing request");
                await context.Response.WriteAsync("Hello World");
            });
        }
    }
}
