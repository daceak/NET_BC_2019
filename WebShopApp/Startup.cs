using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebShop;

namespace WebShopApp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSession(); //pievieno sesijas web app (saglaba datus uz vienu sesiju)
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<WebShopDB>
                (db => db.UseSqlServer(Configuration.GetConnectionString("MyDB"))); 
            //configuration- var pieklut visam kas definets configuracija (appsettings.json)
           //visur kur saja projekta tiks izmantots WebSHopDb visut tiks izmantota si klase, 
            //jo seit addDb context nosaka, ka visur kur izmantota klase WebSHopDb japielieto datubazi kas noradita zem MyDB
           //Dependency injection- automatiski tiek pielikts

            services.AddScoped<CategoryManager>(); //veidot sos manager automatisk, kad sakas aplikacija
            services.AddScoped<ItemManager>();
            services.AddScoped<UserManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            //app.UseCookiePolicy(); atstat ja ir Http, ja https (secure) tad aizkomentet

            app.UseSession(); //pielietot pirms tam pievienotos session

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
