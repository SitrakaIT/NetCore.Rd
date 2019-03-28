using NetCore.Rd.Core.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Rd.Core.Business
{
    public interface IGenericBusiness<TEntity> : IGenericCore<TEntity>, IGenericTransactCore<TEntity> where TEntity : class
    {
    }
}
