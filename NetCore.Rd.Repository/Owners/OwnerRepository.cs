using Microsoft.EntityFrameworkCore;
using NetCore.Rd.Core.Repository;
using NetCore.Rd.Data.Context;
using NetCore.Rd.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.Rd.Repository.Owners
{
    public class OwnerRepository : GenericRepository<Owner, ApplicationContext, IOwnerRepository>, IOwnerRepository
    {
        private readonly ApplicationContext __context;

        public OwnerRepository(ApplicationContext context) : base(context)
        {
            __context = context;
        }

        public async Task<List<Owner>> GetAllOwners()
        {
            var query = await __context.Owners.ToListAsync();

            return query;
        }
    }
}
