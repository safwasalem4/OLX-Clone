

using Mapper.Contracts;
using Models.DTO;
using Models.Models;

namespace Mapper.Mappers
{
    public class UserMapper : IUserMapper
    {
        public ApplicationUser MapFromDTO(UserDTO userDTO)
        {
            ApplicationUser user = new();
            user.UserName = userDTO.UserName;
            user.FName = userDTO.FirstName;
            user.LName = userDTO.LastName;
            user.Email = userDTO.Email;
            user.PhoneNumber = userDTO.Phone;
            user.AboutMe = userDTO.AboutMe;
            return user;
        }

        public UserDTO MapToDTO(ApplicationUser user)
        {
            UserDTO userDTO = new();
            userDTO.UserName = user.UserName;
            userDTO.FirstName = user.FName;
            userDTO.LastName = user.LName;
            userDTO.Email = user.Email;
            userDTO.AboutMe = user.AboutMe;
            userDTO.Phone = user.PhoneNumber;
            return userDTO;
        }
    }
}
