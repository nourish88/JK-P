using Business.Services;
using Business.Services.Bases;
using Business.Utils;
using Business.Utils.Bases;
using Core.Business.Utils;
using Core.Business.Utils.Bases;
using Core.DataAccess.EntityFramework;
using Core.DataAccess.EntityFramework.Bases;
using DataAccess.Configs;
using DataAccess.EntityFramework;
using DataAccess.EntityFramework.Bases;
using DataAccess.EntityFramework.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVC.Settings;

namespace MVC
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
            services.AddControllersWithViews();

            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddSession();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(config =>
                {
                    config.LoginPath = "/Kullanici/Login";
                    config.AccessDeniedPath = "/Kullanici/AccessDenied";
                });

            services.AddScoped<IOlayIhbarService, OlayIhbarService>();
            services.AddScoped<IPersonelIhbarService, PersonelIhbarService>();
            services.AddScoped<IFaaliyetService, FaaliyetService>();
            services.AddScoped<IIslemDurumuService, IslemDurumuService>();
            services.AddScoped<IOlayService, OlayService>();
            services.AddScoped<IPersonelService, PersonelService>();
            services.AddScoped<IIhbarDurumuService, IhbarDurumuService>();
            services.AddScoped<IIhbarService, IhbarService>();
            services.AddScoped<IKullaniciService, KullaniciService>();
            services.AddScoped<IRolService, RolService>();

            services.AddScoped<OlayIhbarDalBase, OlayIhbarDal>();
            services.AddScoped<PersonelIhbarDalBase, PersonelIhbarDal>();
            services.AddScoped<FaaliyetDalBase, FaaliyetDal>();
            services.AddScoped<IslemDurumuDalBase, IslemDurumuDal>();
            services.AddScoped<OlayDalBase, OlayDal>();
            services.AddScoped<PersonelDalBase, PersonelDal>();
            services.AddScoped<IhbarDurumuDalBase, IhbarDurumuDal>();
            services.AddScoped<IhbarDalBase, IhbarDal>();
            services.AddScoped<KullaniciDalBase, KullaniciDal>();
            services.AddScoped<RolDalBase, RolDal>();

            services.AddScoped<SqlBase, Sql>();

            Config.ConnectionString = Configuration.GetConnectionString("JkiContext");
            services.AddScoped<DbContext, JkiContext>();

            services.AddScoped<TimeUtilBase, TimeUtil>();

            services.AddScoped<IControllerUtil, ControllerUtil>();

            AppSettings appSettings = new AppSettings();
            var section = Configuration.GetSection("AppSettings"); 
            section.Bind(appSettings);
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
