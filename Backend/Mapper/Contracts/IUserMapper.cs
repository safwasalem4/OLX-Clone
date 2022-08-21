using Models.DTO;
using Models.Models;


namespace Mapper.Contracts
{
    public interface IUserMapper
    {
        ApplicationUser MapFromDTO(UserDTO userDTO);
        UserDTO MapToDTO(ApplicationUser user);
    }
}
