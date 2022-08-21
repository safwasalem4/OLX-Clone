using Models.DTO;

namespace Services
{
    public interface ILocationService
    {
        IEnumerable<LocationDTO> GetAll();
        LocationDTO GetById(int id);
        LocationDTO Add(LocationDTO locationDTO);
        void Update(int id, LocationDTO locationDTO);
        void Delete(int id);
        bool LocationExists(int id);
        void SaveLocation();
    }
}
