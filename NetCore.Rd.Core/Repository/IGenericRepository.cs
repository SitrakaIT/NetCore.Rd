using NetCore.Rd.Core.Generic;

namespace NetCore.Rd.Core.Repository
{
    public interface IGenericRepository<TEntity> : IGenericCore<TEntity> where TEntity : class
    {
    }
}
