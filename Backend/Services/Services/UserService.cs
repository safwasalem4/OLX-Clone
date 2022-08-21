
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using Services.Contracts;
using System.Security.Claims;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        /// <summary>
        /// Returns userDTO from token
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="userManager"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> GetUserByIdAsync(ClaimsIdentity identity)
        {
            int userId = 0;

            // if claims exists
            if (identity != null)
            {
                // get user nameid claim
                userId = int.Parse(identity.Claims.First(x => x.Type.Contains("nameidentifier")).Value);
            }

            // find user by id
            var user = await _userManager.FindByIdAsync(userId.ToString());
            return user;
        }


        /// <summary>
        /// Edit user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userManager"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<ApplicationUser> UpdateUserAsync(ClaimsIdentity identity, UserDTO model)
        {
            var user = await GetUserByIdAsync(identity);
            user.AboutMe = model.AboutMe;
            user.PhoneNumber = model.Phone;
            user.FName = model.FirstName;
            user.LName = model.LastName;
            user.NormalizedEmail = model.Email.ToUpper();
            user.Email = model.Email;


            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Delete User 
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="userManager"></param>
        /// <returns></returns>
        public async Task<StatusCodeResult> DeleteUserAsync(ClaimsIdentity identity)
        {
            var user = await GetUserByIdAsync(identity);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return new StatusCodeResult(204);
            }
            else
            {
                return new StatusCodeResult(400);
            }
        }
    }
}
