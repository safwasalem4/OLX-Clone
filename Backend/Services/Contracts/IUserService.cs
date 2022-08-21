using Mapper.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using System.Security.Claims;

namespace Services.Contracts
{
    public interface IUserService
    {
        public Task<ApplicationUser> GetUserByIdAsync(ClaimsIdentity identity);
        public Task<ApplicationUser> UpdateUserAsync(ClaimsIdentity identity, UserDTO model);
        public Task<StatusCodeResult> DeleteUserAsync(ClaimsIdentity identity);
    }
}
