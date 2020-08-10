using Business.Services;
using Business.Services.Bases;
using Core.Business.Helpers.Security.Identity;
using Core.Business.Models.Security.Identity;
using Core.Business.Utils.Security.Identity;
using Core.Business.Utils.Security.Identity.Bases;
using Core.DataAccess.EntityFramework;
using Core.DataAccess.EntityFramework.Bases;
using DataAccess.Configs;
using DataAccess.EntityFramework;
using DataAccess.EntityFramework.Bases;
using DataAccess.EntityFramework.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace WebApi
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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });

            var section = Configuration.GetSection("JwtOptions");
            JwtOptions jwtOptions = new JwtOptions();
            section.Bind(jwtOptions);
            var securityKeyHelper = new SecurityKeyHelper();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = securityKeyHelper.CreateSecurityKey(jwtOptions.SecurityKey)
                    };
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
            services.AddScoped<IAuthService, AuthService>();

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

            services.AddSingleton<JwtUtilBase, JwtUtil>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
