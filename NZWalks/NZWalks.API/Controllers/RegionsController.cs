using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Dtos;
using NZWalks.API.Entities;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<RegionDto>))]
        public async Task<IActionResult> Get()
        {
            var regions = await _regionRepository.GetAll();
            var regionsDto = _mapper.Map<List<RegionDto>>(regions);  
            return Ok(regionsDto);
        }
    }
}
