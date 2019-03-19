using NetCore.Rd.Core.Business;
using NetCore.Rd.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.Rd.Business.Owners
{
    public interface IOwnerBusiness : IGenericBusiness<Owner>
    {
        Task<List<Owner>> GetAllOwners();
    }
}
