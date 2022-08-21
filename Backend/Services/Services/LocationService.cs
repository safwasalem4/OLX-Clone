using Data.Infrastructure;
using Data.Repositories.Contracts;
using Mapper.Contracts;
using Models.DTO;
using Models.Models;

namespace Services.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ILocationMapper _locationMapper;
        private readonly IUnitOfWork _unitOfWork;

        public LocationService(ILocationRepository locationRepository, ILocationMapper locationMapper, IUnitOfWork unitOfWork)
        {
            _locationRepository = locationRepository;
            _locationMapper = locationMapper;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<LocationDTO> GetAll()
        {
            IEnumerable<Location> locations = _locationRepository.GetAll();
            IEnumerable<LocationDTO> locationsDTO = locations.Select(location => _locationMapper.MapToDTO(location));
            return locationsDTO;
        }

        public LocationDTO GetById(int id)
        {
            Location location = _locationRepository.GetById(id);
            LocationDTO locationDTO = _locationMapper.MapToDTO(location);
            return locationDTO;
        }

        public LocationDTO Add(LocationDTO locationDTO)
        {
            var location = _locationMapper.MapFromDTO(locationDTO);
            Location addedLocation = _locationRepository.Add(location);
            LocationDTO result = _locationMapper.MapToDTO(addedLocation);
            return result;
        }

        public void Update(int id, LocationDTO locationDTO)
        {
            Location location = _locationMapper.MapFromDTO(locationDTO);
            _locationRepository.Update(id, location);

        }
        public void Delete(int id)
        {
            Location location = _locationRepository.GetById(id);
            _locationRepository.Delete(location);
        }
        public bool LocationExists(int id)
        {
            Location location = _locationRepository.GetById(id);
            return location != null;
        }
        public void SaveLocation()
        {
            _unitOfWork.Commit();
        }
    }
}
