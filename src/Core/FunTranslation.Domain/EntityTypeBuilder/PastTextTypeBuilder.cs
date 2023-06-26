using FunTranslation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Domain.EntityTypeBuilder
{
    public class PastTextTypeBuilder : IEntityTypeConfiguration<PastText>
    {
        public void Configure(EntityTypeBuilder<PastText> builder)
        {
            builder.Property(x => x.MainText)
                 .IsRequired()
                 .HasColumnType("nvarchar")
                 .HasMaxLength(1050);

            builder.Property(x => x.TranslateText)
                 .IsRequired()
                 .HasColumnType("nvarchar")
                 .HasMaxLength(1050);

        }
    }
}
