using FunTranslation.Application.Interfaces.IServices;
using FunTranslation.Domain.Entities.Identity;
using FunTranslation.Infrastructure.Services;
using FunTranslation.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IPastTextService, PastTextService>();
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

            //services.AddAuthentication();
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<FunTranslationContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = "/Login/Index";
                opt.LogoutPath = "/Login/Logout";
                opt.Cookie = new CookieBuilder
                {
                    Name = "AspNetCoreIdentityFunTranslate",
                    HttpOnly = true,
                    SecurePolicy = CookieSecurePolicy.Always
                };

                opt.SlidingExpiration = true;
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            });




        }


    }
}
