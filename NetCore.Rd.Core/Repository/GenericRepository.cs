using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NetCore.Rd.Core.Repository
{
    public abstract class GenericRepository<TEntity, TContext, TRepository> : IGenericRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
        where TRepository : IGenericRepository<TEntity>
    {
        protected readonly TContext _context;

        public GenericRepository(TContext context) => _context = context;

        public virtual TEntity Add(TEntity t)
        {
            _context.Set<TEntity>().Add(t);
            _context.SaveChanges();
            return t;
        }

        public virtual async Task<TEntity> AddAsync(TEntity t)
        {
            _context.Set<TEntity>().Add(t);
            await _context.SaveChangesAsync();
            return t;
        }

        public int Count() => _context.Set<TEntity>().Count();

        public async Task<int> CountAsync() => await _context.Set<TEntity>().CountAsync();

        public int CountWhere(Expression<Func<TEntity, bool>> match) => _context.Set<TEntity>().Count(match);

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> match) => _context.Set<TEntity>().SingleOrDefault(match);

        public virtual async Task<IQueryable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
            => (await ((IQueryable<TEntity>)_context.Set<TEntity>()).Where(match).ToListAsync()).AsQueryable();

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match) => await _context.Set<TEntity>().SingleOrDefaultAsync(match);

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate) => _context.Set<TEntity>().Where(predicate);

        public virtual TEntity Get(int id) => _context.Set<TEntity>().Find(id);

        public IQueryable<TEntity> GetAll() => _context.Set<TEntity>();

        public virtual async Task<IQueryable<TEntity>> GetAllAsync()
            => (await ((IQueryable<TEntity>)_context.Set<TEntity>()).ToListAsync()).AsQueryable();

        public virtual async Task<TEntity> GetAsync(int id) => await _context.Set<TEntity>().FindAsync(id);

        public virtual void Save() => _context.SaveChanges();

        public async virtual Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public virtual TEntity Update(TEntity t, object key)
        {
            if (t == null)
                return null;
            TEntity exist = _context.Set<TEntity>().Find(key);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(t);
                _context.SaveChanges();
            }
            return exist;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity t, object key)
        {
            if (t == null)
                return null;
            TEntity exist = await _context.Set<TEntity>().FindAsync(key);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(t);
                await _context.SaveChangesAsync();
            }
            return exist;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
