using NetCore.Rd.Core.Repository;
using NetCore.Rd.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Rd.Repository.Apartments
{
    public interface IApartmentRepository : IGenericRepository<Apartment>
    {
        Task<IQueryable<Apartment>> GetAllApartmentsAsync();
    }
}
