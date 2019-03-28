using Microsoft.EntityFrameworkCore;
using NetCore.Rd.Core.Repository;
using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NetCore.Rd.Core.Business
{
    public class GenericBusiness<TEntity, TContext, TRepository, TBusiness> : IGenericBusiness<TEntity>
        where TEntity : class
        where TContext : DbContext
        where TRepository : IGenericRepository<TEntity>
        where TBusiness : IGenericBusiness<TEntity>
    {
        protected readonly TRepository _repository;

        public GenericBusiness(TRepository repository) => _repository = repository;

        public virtual TEntity Add(TEntity t)
        {
            _repository.Add(t);
            return t;
        }

        public virtual async Task<TEntity> AddAsync(TEntity t)
        {
            await _repository.AddAsync(t);
            return t;
        }

        public int Count() => _repository.Count();

        public async Task<int> CountAsync() => await _repository.CountAsync();

        public int CountWhere(Expression<Func<TEntity, bool>> match) => _repository.CountWhere(match);

        public virtual void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            return await _repository.DeleteAsync(entity);
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> match) => _repository.Find(match);

        public virtual async Task<IQueryable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match) => await _repository.FindAllAsync(match);

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match) => await _repository.FindAsync(match);

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate) => _repository.FindBy(predicate);

        public virtual TEntity Get(int id) => _repository.Get(id);

        public IQueryable<TEntity> GetAll() => _repository.GetAll();

        public virtual async Task<IQueryable<TEntity>> GetAllAsync() => await _repository.GetAllAsync();

        public virtual async Task<TEntity> GetAsync(int id) => await _repository.GetAsync(id);

        public virtual TEntity Update(TEntity t, object key) => _repository.Update(t, key);

        public virtual async Task<TEntity> UpdateAsync(TEntity t, object key) => await _repository.UpdateAsync(t, key);

        public virtual void Save() => _repository.Save();

        public async virtual Task<int> SaveAsync() => await _repository.SaveAsync();

        public void Dispose()
        {
            _repository.Dispose();
        }

        public async Task<IEnumerable> QueryBySP(string name, params Tuple<string, string>[] paramCollections)
        {
            return await _repository.QueryBySP(name, paramCollections);
        }

    }
}
