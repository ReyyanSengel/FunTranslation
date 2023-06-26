using FunTranslation.Application.Interfaces.IRepositories;
using FunTranslation.Application.Interfaces.IServices;
using FunTranslation.Application.Interfaces.IUnitOfWork;
using FunTranslation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Infrastructure.Services
{
    public class LanguageService : GenericService<Language>, ILanguageService
    {
        public LanguageService(IGenericRepository<Language> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
