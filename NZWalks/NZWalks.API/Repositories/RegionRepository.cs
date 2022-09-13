using Microsoft.EntityFrameworkCore;
using NZWalks.API.Dtos;
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

        public async Task<Region> Add(Region region)
        {
            await _context.AddAsync(region);
            _ = await _context.SaveChangesAsync();
            return region;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await Get(id);
            if(entity is null)
            {
                return false;
            }
            _context.Regions.Remove(entity);
            _ = await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Region> Get(Guid id)
        {
            var region = await _context.Regions.FirstOrDefaultAsync(r => r.Id == id);
            return region;
        }

        public async Task<List<Region>> GetAll()
        {
            var regions = await _context.Regions.ToListAsync();
            return regions;
        }

        public async Task<bool> Update(Guid id, Region region)
        {
            var entity = await Get(id);
            if (entity is null) return false;
            _context.Entry(entity).CurrentValues.SetValues(region);
            _ = _context.SaveChangesAsync();
            return true;
        }
    }
}
