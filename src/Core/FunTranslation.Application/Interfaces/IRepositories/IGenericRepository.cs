using FunTranslation.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Application.Interfaces.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAll();

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);

        Task<TEntity> AddAsync(TEntity entity);

        Task AddRangeAsync(IQueryable<TEntity> entities);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        void RemoveRange(IQueryable<TEntity> entities);

        IQueryable<TEntity> Query();
    }
}
