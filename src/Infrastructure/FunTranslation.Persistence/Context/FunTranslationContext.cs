using FunTranslation.Application.AuthenticatedUser;
using FunTranslation.Domain.Entities;
using FunTranslation.Domain.Entities.Common;
using FunTranslation.Domain.Entities.Identity;
using FunTranslation.Domain.EntityTypeBuilder;
using FunTranslation.Domain.Seeds;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FunTranslation.Persistence.Context
{
    public class FunTranslationContext : IdentityDbContext<AppUser, AppRole, int>
    {
        private int _userId;
        public FunTranslationContext(DbContextOptions<FunTranslationContext> options, UserResolverService userService) : base(options)
        {
            _userId = userService.GetUserId();
        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<PastText> Texts { get; set; }

        
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReferans)
                {
                    switch (item.State)
                    {

                        case EntityState.Added:
                            {
                                entityReferans.CreateDate = DateTime.Now;
                                entityReferans.CreateUserId = _userId;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReferans).Property(x => x.CreateDate).IsModified = false;
                                entityReferans.UpdateDate = DateTime.Now;
                                entityReferans.UpdateUserId = _userId;
                                break;
                            }

                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReferans)
                {
                    switch (item.State)
                    {

                        case EntityState.Added:
                            {
                                entityReferans.CreateDate = DateTime.Now;
                                entityReferans.CreateUserId = _userId;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReferans).Property(x => x.CreateDate).IsModified = false;
                                entityReferans.UpdateDate = DateTime.Now;
                                entityReferans.UpdateUserId = _userId;
                                break;
                            }

                    }
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder
                .ApplyConfiguration(new LanguageTypeBuilder())
                .ApplyConfiguration(new PastTextTypeBuilder());

            builder
                .ApplyConfiguration(new LanguageSeedData());

            base.OnModelCreating(builder);
        }
    }


}
