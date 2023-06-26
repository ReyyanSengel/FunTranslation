using FunTranslation.Application.AuthenticatedUser;
using FunTranslation.Application.Interfaces.IRepositories;
using FunTranslation.Application.Interfaces.IUnitOfWork;
using FunTranslation.Domain.Entities.Identity;
using FunTranslation.Persistence.Context;
using FunTranslation.Persistence.Repositories;
using FunTranslation.Persistence.UnitOfWorks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FunTranslation.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<FunTranslationContext>(
                options => options.UseSqlServer(connectionString),ServiceLifetime.Scoped);
            services.AddTransient<UserResolverService>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IPastTextRepository, PastTextRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void DatabaseInitialize(this IApplicationBuilder builder)
        {

            using var serviceScope =
                builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            using var context = serviceScope.ServiceProvider.GetService<FunTranslationContext>();

            if (context == null) return;
            DatabaseMigration(context);

            var roleContext = context.Set<AppRole>();
            var userContext = context.Set<AppUser>();

            var roles = roleContext.Select(p => p.Name).ToArray();
            var userList = userContext.ToList();

            foreach (var user in userList)
            {
                if (user.UserName == "Admin")
                {
                    _ = AssignRoles(serviceScope, user.Email, roles);
                }
                else
                {
                    _ = AssignRoles(serviceScope, user.Email, new string[] { "user" });
                }
            }

            context.SaveChanges();
        }

        public static IdentityResult AssignRoles(IServiceScope? serviceScope, string email, string[] roles)
        {
            UserManager<AppUser> _userManager = (UserManager<AppUser>)serviceScope.ServiceProvider.GetService(typeof(UserManager<AppUser>));
            AppUser user = _userManager.FindByEmailAsync(email).Result;
            var result = _userManager.AddToRolesAsync(user, roles).Result;

            return result;
        }

        private static void DatabaseMigration(FunTranslationContext context)
        {
            context.Database.Migrate();
        }
    }
}
