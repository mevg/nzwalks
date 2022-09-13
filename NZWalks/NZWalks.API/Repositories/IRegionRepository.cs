using NZWalks.API.Dtos;
using NZWalks.API.Entities;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        public Task<List<Region>> GetAll();
        public Task<Region> Get(Guid id);

        public Task<Region> Add(Region region);

        public Task<bool> Delete(Guid id);

        public Task<bool> Update(Guid id, Region region);
    }
}
