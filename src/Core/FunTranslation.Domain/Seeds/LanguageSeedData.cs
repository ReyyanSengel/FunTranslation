using FunTranslation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Domain.Seeds
{
    public class LanguageSeedData : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasData(
                new Language
                {
                    Id = 1,
                    Name = "Yoda",
                    CreateUserId = 1,
                    CreateDate = DateTime.Now
                },
                new Language
                {
                    Id = 2,
                    Name = "Priate",
                    CreateUserId = 2,
                    CreateDate = DateTime.Now
                },
                new Language
                {
                    Id = 3,
                    Name = "Minion",
                    CreateUserId = 1,
                    CreateDate = DateTime.Now
                },
                new Language
                {
                    Id = 4,
                    Name = "Hodor",
                    CreateUserId = 2,
                    CreateDate = DateTime.Now
                });
        }
    }
}
