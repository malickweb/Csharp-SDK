using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace myWebApp
{
    public class Startup
    {
        public static Kameleoon.IKameleoonClient kameleoonClient;
        public Startup(IConfiguration configuration)
        {
            string ConfigurationPath = "./wwwroot/kameleoon/csharp-client.conf";
            string SiteCode = "y5ofsuw2jj";
            // string Client_id = "10277-mbelgrine-sdk";
            // string Client_secret = "AnzoAyeuK8nvKckZtOga5zuRhJKJwlZ4qZtBC4IMUUI";

            Configuration = configuration;
            // kameleoonClient = Kameleoon.KameleoonClientFactory.Create(SiteCode, true, ConfigurationPath, Client_id, Client_secret);
            kameleoonClient = Kameleoon.KameleoonClientFactory.Create(SiteCode, false, ConfigurationPath);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                // endpoints.MapDefaultControllerRoute();
                // endpoints.MapControllerRoute(
                //     name: "default",
                //     pattern: "{controller=Index}/{action=Index}/{id?}"
                // );
                // endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}");
                // endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
