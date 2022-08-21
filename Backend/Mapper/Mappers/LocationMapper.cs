using Mapper.Contracts;
using Models.DTO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Mappers
{
    public class LocationMapper : ILocationMapper
    {
        public Location MapFromDTO(LocationDTO locationDTO)
        {
            Location location = new Location();
            location.LocationId = locationDTO.LocationId;
            location.CityName = locationDTO.CityName;
            return location;
        }

        public LocationDTO MapToDTO(Location location)
        {
            LocationDTO locationDTO = new LocationDTO();
            locationDTO.LocationId = location.LocationId;
            locationDTO.CityName = location.CityName;
            return locationDTO;
        }
    }
}
