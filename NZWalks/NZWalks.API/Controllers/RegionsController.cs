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

        [HttpGet("{id:guid}")]
        [ProducesResponseType(200, Type = typeof(RegionDto))]
        [ProducesResponseType(404, Type = typeof(RegionDto))]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var region = await _regionRepository.Get(id);
            if (region is null) return NotFound();
            var dto = _mapper.Map<Region>(region);
            return Ok(dto);

        }

        [HttpPost("")]
        [ProducesResponseType(201, Type = typeof(RegionDto))]
        public async Task<IActionResult> Post([FromBody] CreateRegionDto regionDto)
        {
            var entity = _mapper.Map<Region>(regionDto);
            _ = await _regionRepository.Add(entity);
            var region = _mapper.Map<Region>(entity);
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, region);

        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _regionRepository.Delete(id);
            if (!deleted) return NotFound();
            return Ok();

        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(Guid id, [FromBody] RegionDto regionDto)
        {
            var entity = _mapper.Map<Region>(regionDto);
            var updated = await _regionRepository.Update(id, entity);
            if (!updated) return NotFound();
            return Ok();

        }
    }
}
