using AutoMapper;
using NZWalks.API.Dtos;
using NZWalks.API.Entities;

namespace NZWalks.API.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionDto>();
        }
    }
}
