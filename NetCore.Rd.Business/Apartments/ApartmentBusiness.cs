using NetCore.Rd.Data.Context;
using NetCore.Rd.Data.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using NetCore.Rd.Core.Business;
using NetCore.Rd.Repository.Apartments;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace NetCore.Rd.Business.Apartments
{
    public class ApartmentBusiness : GenericBusiness<Apartment, ApplicationContext, IApartmentRepository, IApartmentBusiness>, IApartmentBusiness
    {
        private readonly IApartmentRepository _apartmentRepository;
        public ApartmentBusiness(IApartmentRepository repository) : base(repository)
        {
            _apartmentRepository = repository;
        }

        public async Task<IQueryable<Apartment>> GetAllApartmentsAsync()
        {
            var query = await _apartmentRepository.GetAllApartmentsAsync();

            return query;
        }
    }
}