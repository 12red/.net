using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        //    services.Add(new ServiceDescriptor(typeof(datas), new datas(Configuration.GetConnectionString("Default Connection"))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

            });

            app.UseMvc(routes =>
            {
                app.UseAuthentication();

                routes.MapRoute(
                    name: "registration",
                    template: "{controller=Home}/{action=register}/{id?}");
            });

            app.UseMvc(routes =>
            {
                app.UseAuthentication();

                routes.MapRoute(
                    name: "writings",
                    template: "{controller=Home}/{action=write}/{id?}");
            });

            app.UseMvc(routes =>
            {
                app.UseAuthentication();

                routes.MapRoute(
                    name: "login",
                    template: "{controller=Home}/{action=login}/{id?}");
            });

            app.UseMvc(routes =>
            {
                app.UseAuthentication();

                routes.MapRoute(
                    name: "editing",
                    template: "{controller=Home}/{action=writing}/{id?}");
            });


        }
    }
}
