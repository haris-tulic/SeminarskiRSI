using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoprevoznicko_preduzece_HTS.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAutoprevozncniko.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace WebAutoprevozncniko
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
            services.AddDbContext<MyContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DB")));//KONEKCIJSKI STRING--appsettings    OVO SAM ZAKOMENTARISO (PUCA)
            services.AddControllersWithViews();

            // services.AddMvc();// ne znam treba li
            services.AddDistributedMemoryCache();// in memori 
            services.AddSession();// i sesija
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHubContext<NotifikacijskiHub> hubContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseSession();//za koristenje sesije

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<NotifikacijskiHub>("/notifikacijskiHub");

            });
            //da mi je znati što puca ovdje 
        }
    }
}

