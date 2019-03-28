using NetCore.Rd.Core.Generic;

namespace NetCore.Rd.Core.Repository
{
    public interface IGenericRepository<TEntity> : IGenericCore<TEntity>, IGenericTransactCore<TEntity> where TEntity : class
    {
    }
}
