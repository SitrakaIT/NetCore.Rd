using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCore.Rd.Business.Apartments;
using NetCore.Rd.Data.Dto;
using NetCore.Rd.Data.Dto.Generic;
using NetCore.Rd.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Rd.Web.Controllers.API
{
    [EnableCors("AllowSpecificOrigin")]
    public class ApartmentApiController : Controller
    {
        private readonly IApartmentBusiness _apartmentBusiness;
        private readonly IMapper _mapper;
        private readonly ILogger<ApartmentApiController> _logger;
        public ApartmentApiController(IApartmentBusiness apartmentBusiness, IMapper mapper, ILogger<ApartmentApiController> logger)
        {
            _apartmentBusiness = apartmentBusiness;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("~/api/apartments")]
        public async Task<IActionResult> GetAllApartmentsAsync()
        {
            try
            {
                _logger.LogInformation("Get all apartments");
                var apartmentList = await _apartmentBusiness.GetAllApartmentsAsync();
                var concreteApartmentList = _mapper.Map<List<Apartment>, List<ApartmentDto>>(apartmentList.ToList());

                var response = new GenericResponseDto<ApartmentDto>(GenericResponseType.DataCollection, concreteApartmentList)
                {
                    Message = "Get all apartments",
                    Success = true
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                GenericResponseDto<Apartment> response = new GenericResponseDto<Apartment>(GenericResponseType.Error)
                {
                    Message = $"Error getting list of apartments. /n More details : {e.Message}",
                    Success = false
                };

                return Ok(response);
            }
        }

        [HttpGet]
        [Route("~/api/apartments/{id}")]
        public async Task<IActionResult> GetApartment(int id)
        {
            try
            {
                _logger.LogInformation("Get an apartment");

                var apartment = await _apartmentBusiness.GetAsync(id);

                var response = new GenericResponseDto<Apartment>(GenericResponseType.DataEntity, null, apartment)
                {
                    Message = $"Getting apartment number {apartment.ID}",
                    Success = true
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                GenericResponseDto<Apartment> response = new GenericResponseDto<Apartment>(GenericResponseType.Error)
                {
                    Message = $"Error adding apartment. /n More details : {e.Message}",
                    Success = false
                };

                return Ok(response);
            }
        }

        [HttpPost]
        [Route("~/api/apartments/create")]
        public async Task<IActionResult> CreateApartmentAsync([FromBody] Apartment apartment)
        {
            try
            {
                _logger.LogInformation("Insert new apartment");
                var newApartment = new Apartment
                {
                    ApartmentName = apartment.ApartmentName,
                    DateCreation = DateTime.Now,
                    IdentifierApartment = Guid.NewGuid(),
                    ApartmentNumber = await _apartmentBusiness.CountAsync() + 1,
                    OwnerID = apartment.OwnerID
                };

                await _apartmentBusiness.AddAsync(newApartment);
                await _apartmentBusiness.SaveAsync();

                var response = new GenericResponseDto<Apartment>(GenericResponseType.DataEntity, null, newApartment)
                {
                    Message = $"Apartment number {newApartment.ID} created",
                    Success = true
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                GenericResponseDto<Apartment> response = new GenericResponseDto<Apartment>(GenericResponseType.Error)
                {
                    Message = $"Error adding apartment. /n More details : {e.Message}",
                    Success = false
                };

                return Ok(response);
            }
        }

        [HttpPost]
        [Route("~/api/apartments/edit/{id}")]
        public async Task<IActionResult> EditApartmentAsync([FromBody] Apartment apartment, int id)
        {
            try
            {
                _logger.LogInformation("Edition of apartment");
                var apartmentToUpdate = _apartmentBusiness.Get(id);

                var apartmentForUpdate = new Apartment
                {
                    ID = id,
                    ApartmentName = (!String.IsNullOrEmpty(apartment.ApartmentName)) ? apartment.ApartmentName : apartmentToUpdate.ApartmentName,
                    IdentifierApartment = (apartmentToUpdate.IdentifierApartment == Guid.Empty) ? Guid.NewGuid() : apartmentToUpdate.IdentifierApartment,
                    ApartmentNumber = apartment?.ApartmentNumber == 0 ? await _apartmentBusiness.CountAsync() + 1 : apartmentToUpdate.ApartmentNumber,
                    OwnerID = apartment?.OwnerID,
                    DateEdition = DateTime.Now
                };

                var apartmentUpdated = await _apartmentBusiness.UpdateAsync(apartmentForUpdate, id);

                var response = new GenericResponseDto<Apartment>(GenericResponseType.DataEntity, null, apartmentUpdated)
                {
                    Message = $"Apartment number {apartmentUpdated.ID} Updated",
                    Success = true,
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                GenericResponseDto<Apartment> response = new GenericResponseDto<Apartment>(GenericResponseType.Error)
                {
                    Message = $"Apartment Edition throws exception. /n More details : {e.Message}",
                    Success = false
                };

                return Ok(response);
            }
        }

        [HttpPost]
        [Route("~/api/apartment/delete/{id}")]
        public async Task<IActionResult> DeleteApartmentAsync([FromRoute] int id)
        {
            try
            {
                var apartmentToDelete = await _apartmentBusiness.GetAsync(id);

                await _apartmentBusiness.DeleteAsync(apartmentToDelete);

                return Ok("Deletion completed");
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        [HttpGet]
        [Route("~/api/apartment/{name}")]
        public async Task<IActionResult> FindByName([FromRoute] string name)
        {
            try
            {
                var res = await _apartmentBusiness.QueryBySP("ApartmentResearchPerOwners", Tuple.Create("@ApartmentName", name));
                return Ok(res);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
                throw;
            }
        }

    }
}
