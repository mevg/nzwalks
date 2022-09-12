using Microsoft.EntityFrameworkCore;
using NZWalks.API.Entities;
using NZWalks.API.Persistence;

namespace NZWalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly AppDbContext _context;

        public RegionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Region>> GetAll()
        {
            var regions = awit _context.Regions.ToListAsync();
            return regions;
        }
    }
}
