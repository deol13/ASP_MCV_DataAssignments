using ASP_MCV_DataAssignments.Data;
using ASP_MCV_DataAssignments.Models;
using ASP_MCV_DataAssignments.Models.Repo;
using ASP_MCV_DataAssignments.Models.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using JavaScriptEngineSwitcher.V8;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using React.AspNet;

namespace ASP_MCV_DataAssignments
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();
            // Make sure a JS engine is registered, or you will get an error!
            services.AddJsEngineSwitcher(options => options.DefaultEngineName = V8JsEngine.EngineName).AddV8();

            services.AddControllersWithViews();
            services.AddRazorPages(); //Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<PeopleDbContext>()
                .AddDefaultTokenProviders(); //Identity

            //services.AddScoped<IPeopleRepo, InMemoryPeopleRepo>();

            services.AddScoped<IPeopleRepo, DatabasePeopleRepo>();
            services.AddScoped<IPeopleService, PeopleService>();

            services.AddScoped<ICityRepo, CityRepo>();
            services.AddScoped<ICityService, CityService>();

            services.AddScoped<ICountryRepo, CountryRepo>();
            services.AddScoped<ICountryService, CountryService>();

            services.AddScoped<ILanguageRepo, LanguageRepo>();
            services.AddScoped<ILanguageService, LanguageService>();

            //An injection, only when already using injection. If you are not using injection, use Dbcontext constructor to create instances
            services.AddDbContext<PeopleDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("PeopleDb")));

            services.AddMvc();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            // Initialise ReactJS.NET. Must be before static files.
            app.UseReact(config =>
            {
                // If you want to use server-side rendering of React components,
                // add all the necessary JavaScript files here. This includes
                // your components as well as all of their dependencies.
                // See http://reactjs.net/ for more information. Example:
                //config
                //  .AddScript("~/js/First.jsx")
                //  .AddScript("~/js/Second.jsx");

                // If you use an external build too (for example, Babel, Webpack,
                // Browserify or Gulp), you can improve performance by disabling
                // ReactJS.NET's version of Babel and loading the pre-transpiled
                // scripts. Example:
                //config
                //  .SetLoadBabel(false)
                //  .AddScriptWithoutTransform("~/js/bundle.server.js");
            });
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); //Identity
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages(); //Identity
            });
        }
    }
}
