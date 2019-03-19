using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NetCore.Rd.Core.Generic
{
    public interface IGenericCore<TEntity> where TEntity : class
    {
        TEntity Add(TEntity t);
        Task<TEntity> AddAsync(TEntity t);
        int Count();
        Task<int> CountAsync();
        int CountWhere(Expression<Func<TEntity, bool>> match);
        void Delete(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);
        TEntity Find(Expression<Func<TEntity, bool>> match);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        Task<IQueryable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match);
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);
        void Save();
        Task<int> SaveAsync();
        TEntity Update(TEntity t, object key);
        Task<TEntity> UpdateAsync(TEntity t, object key);
        void Dispose();

    }
}
