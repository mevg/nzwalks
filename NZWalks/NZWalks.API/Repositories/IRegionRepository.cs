using NZWalks.API.Entities;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        public Task<List<Region>> GetAll();
    }
}
