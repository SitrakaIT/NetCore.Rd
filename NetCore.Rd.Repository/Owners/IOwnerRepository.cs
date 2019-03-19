using NetCore.Rd.Core.Repository;
using NetCore.Rd.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.Rd.Repository.Owners
{
    public interface IOwnerRepository : IGenericRepository<Owner>
    {
        Task<List<Owner>> GetAllOwners();
    }
}
