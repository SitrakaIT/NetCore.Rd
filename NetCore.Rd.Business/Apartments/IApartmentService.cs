using NetCore.Rd.Core.Business;
using NetCore.Rd.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Rd.Business.Apartments
{
    public interface IApartmentBusiness : IGenericBusiness<Apartment>
    {
         Task<IQueryable<Apartment>> GetAllApartmentsAsync();
    }
}