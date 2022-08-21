using Models.DTO;
using Models.Models;

namespace Mapper.Contracts
{
    public interface ILocationMapper
    {
        Location MapFromDTO(LocationDTO locationDTO);
        LocationDTO MapToDTO(Location location);
    }
}
