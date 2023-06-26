using FunTranslation.Application.Interfaces.IRepositories;
using FunTranslation.Application.Interfaces.IUnitOfWork;
using FunTranslation.Persistence.Context;
using FunTranslation.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FunTranslationContext _context;

        

        public UnitOfWork(FunTranslationContext context)
        {
            _context = context;
        }

       
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
