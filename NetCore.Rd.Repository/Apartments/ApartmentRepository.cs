using Microsoft.EntityFrameworkCore;
using NetCore.Rd.Core.Repository;
using NetCore.Rd.Data.Context;
using NetCore.Rd.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Rd.Repository.Apartments
{
    public class ApartmentRepository : GenericRepository<Apartment, ApplicationContext, IApartmentRepository>, IApartmentRepository
    {
        private readonly ApplicationContext __context;
        public ApartmentRepository(ApplicationContext context) : base(context)
        {
            __context = context;
        }

        public async Task<IQueryable<Apartment>> GetAllApartmentsAsync()
        {
            var query = await __context.Apartments.Include(o => o.Owner).ToListAsync();

            return query.AsQueryable();
        }
    }
}
