using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCore.Rd.Business.Owners;
using NetCore.Rd.Data.Dto;
using NetCore.Rd.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.Rd.Web.Controllers.API
{
    public class OwnerApiController : Controller
    {
        private readonly IOwnerBusiness _ownerBusiness;
        private readonly IMapper _mapper;
        public OwnerApiController(IOwnerBusiness ownerBusiness, IMapper mapper)
        {
            _ownerBusiness = ownerBusiness;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("~/api/owners")]
        public async Task<IActionResult> GetAllOwners()
        {
            var ownerList = await _ownerBusiness.GetAllOwners();

            return Ok(_mapper.Map<List<Owner>, List<OwnerDto>>(ownerList));
        }
    }
}
