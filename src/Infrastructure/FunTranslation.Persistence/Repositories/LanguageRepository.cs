using FunTranslation.Application.Interfaces.IRepositories;
using FunTranslation.Domain.Entities;
using FunTranslation.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Persistence.Repositories
{
    public class LanguageRepository : GenericRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(FunTranslationContext context) : base(context)
        {
        }
    }
}
