using FunTranslation.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Application.Interfaces.IServices
{
    public interface IGenericService<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAll();

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);

        Task<TEntity> AddAsync(TEntity entity);

        Task<IQueryable<TEntity>> AddRangeAsync(IQueryable<TEntity> entities);

        TEntity Update(TEntity entity);

        void Remove(TEntity entity);

        void RemoveRange(IQueryable<TEntity> entities);
    }
}
