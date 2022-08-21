using Data.Infrastructure;
using Data.Repositories.Contracts;
using Models.Models;

namespace Data.Repositories.Repositories
{
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        public LocationRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
