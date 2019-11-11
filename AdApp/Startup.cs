using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdsAppLogic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdApp
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

            services.AddScoped<CategoryManager>(); //veidot sos manager automatisk, kad sakas aplikacija
            services.AddScoped<AdManager>();
            services.AddScoped<UserManager>();

            services.AddDbContext<AdsAppDB>(db => db.UseSqlServer(Configuration.GetConnectionString ("MyDB")));

            services.AddSession(); //pievieno sesijas !!!!!

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseHsts();
            }

            app.UseSession(); //lietot sesiju !!!!!
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseCookiePolicy();  atstat ja ir Http, ja https (secure) tad aizkomentet

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Category}/{action=Categories}/{id?}"); //te maina uz default kas atveras lapa, default parasti ir home controller un index skats
            });
        }
    }
}
