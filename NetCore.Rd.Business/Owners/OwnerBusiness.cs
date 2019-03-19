using NetCore.Rd.Core.Business;
using NetCore.Rd.Data.Context;
using NetCore.Rd.Data.Entities;
using NetCore.Rd.Repository.Owners;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.Rd.Business.Owners
{
    public class OwnerBusiness : GenericBusiness<Owner, ApplicationContext, IOwnerRepository, IOwnerBusiness>, IOwnerBusiness
    {
        private readonly IOwnerRepository _ownerRepository;
        public OwnerBusiness(IOwnerRepository repository) : base(repository)
        {
            _ownerRepository = repository;
        }

        public async Task<List<Owner>> GetAllOwners()
        {
            var query = await _ownerRepository.GetAllOwners();

            return query;
        }
    }
}
