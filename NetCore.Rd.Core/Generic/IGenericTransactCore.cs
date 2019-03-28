using System;
using System.Collections;
using System.Threading.Tasks;

namespace NetCore.Rd.Core.Generic
{
    public interface IGenericTransactCore<TEntity> where TEntity : class
    {
        Task<IEnumerable> QueryBySP(string name, params Tuple<string, string>[] paramCollections);
    }
}
