using System;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Airlines.ApplicationCore;
using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Entities;
using Airlines.ApplicationCore.Interfaces;
using Airlines.Web.Mappers;
using Airlines.Infrastructure;
using Airlines.Infrastructure.Identity;
using Airlines.Web.Models;
using Airlines.Web.Models.AdminPanel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.WebEncoders;

namespace Airlines.Web
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
            #if !DEBUG
                string server = Configuration["DbServer"];
                string port = Configuration["DbPort"];
                string user = Configuration["DbUser"];
                string password = Configuration["DbPassword"];
                string applicationDatabaseName = Configuration["Database"];
                string identityDatabaseName = Configuration["IdentityDatabase"];
                
                var appConnectionString = $"Server={server},{port};Initial Catalog={applicationDatabaseName};User ID={user};Password={password};Integrated Security=true";
                var identityConnectionString = $"Server={server},{port};Initial Catalog={identityDatabaseName};User ID={user};Password={password};Integrated Security=true";
            #else
                string appConnectionString = Configuration.GetConnectionString("AirlinesApplicationDb");
                string identityConnectionString = Configuration.GetConnectionString("AirlinesIdentityDb");
            #endif
            services.BindCoreLayer();
            services.BindInfrastructureLayer(appConnectionString, identityConnectionString);
            
            services.AddScoped<IMapper<TravelClassDTO, TravelClassViewModel>, TravelClassMapper>();
            services.AddScoped<IMapper<CityDTO, CityViewModel>, CityMapper>();
            services.AddScoped<IMapper<PlaneOverviewDTO,PlaneOverviewViewModel>, PlaneOverviewMapper>();
            services.AddScoped<IMapper<PlaneFlatDTO, PlaneFlatViewModel>, PlaneFlatMapper>();
            services.AddScoped<IMapper<FoundFlightsDTO, FoundFlightsViewModel>, FoundFlightsMapper>();
            services.AddScoped<IMapper<SearchFlightsDTO, SearchFlightsViewModel>, SearchFlightsMapper>();

            services.Configure<WebEncoderOptions>(options =>
            {
                options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);
            });
            
            ConfigureAuthServices(services);
            services.AddControllersWithViews()
                .AddSessionStateTempDataProvider()
                .AddRazorRuntimeCompilation();
            services.AddSession();
        }

        public void ConfigureAuthServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.Cookie = new CookieBuilder
                {
                    IsEssential = true
                };
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.Cookie.SameSite = SameSiteMode.Lax;
                });
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

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Airport}/{action=Index}/{id?}");
            });
        }
    }
}