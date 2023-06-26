using FluentValidation;
using FluentValidation.AspNetCore;
using FunTranslation.Application.Extension;
using FunTranslation.Application.Filters;
using FunTranslation.Application.Validations;
using FunTranslation.Application.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();

            services.AddFluentValidationAutoValidation();
            services.AddScoped<IValidator<UserRegisterViewModel>, UserRegisterViewModelValidator>();
            services.AddScoped<IValidator<UserLoginViewModel>, UserLoginViewModelValidator>();
            

            services.AddAutoMapper(assm);
            services.AddSingleton<RestClient>();
            services.AddSingleton<IRestExtension, RestExtension>();
            services.AddScoped(typeof(NotFoundFilter<>));

        }

    }
}
