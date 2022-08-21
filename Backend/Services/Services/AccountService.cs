using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using Services.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Services
{
    public class AccountService : ControllerBase, IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ITokenService _token;
        private readonly IUserService _user;

        public AccountService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, 
            ITokenService token, IUserService user)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _token = token;
            _user = user;
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userManager"></param>
        /// <returns></returns>
        public async Task<IActionResult> RegisterAsync(RegisterDTO model)
        {
            // check if user exists
            var userCheck = await _userManager.FindByNameAsync(model.Username);
            if (userCheck != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                { Status = "Error", Message = "User Already Exists" });
            }

            // create user
            ApplicationUser user = new()
            {
                // snapshot of current user credientials, if they change, security stamp will change
                SecurityStamp = Guid.NewGuid().ToString(),
                // user fields
                UserName = model.Username,
                Email = model.Email,
                FName = model.FName,
                LName = model.LName,
                AboutMe = model.AboutMe,
                PhoneNumber = model.Phone
            };


            // bind user and role
            var resultUser = await _userManager.CreateAsync(user, model.Password);
            if (!resultUser.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Errors = resultUser.Errors });
            }
            var resultRole = await _userManager.AddToRoleAsync(user, "User");

            // if fail
            if (!resultRole.Succeeded && !resultUser.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            }

            // if succeeded
            return Created("", new { Status = "Success", Message = "User created successfully!" });
        }



        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        /// <param name="_token"></param>
        /// <returns></returns>
        public async Task<IActionResult> LoginAsync(LoginDTO model)
        {
            // check if username exists
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
                return NotFound(new { Status = "Error", Message = "Username Doesn't Exist!!" });

            // check if passowrd is correct
            if (await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var roles = await _userManager.GetRolesAsync(user);
                var token = await _token.CreateToken(user, roles, _roleManager);

                return Ok(new
                {
                    Message = "Login Successful",
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                });
            }
            return Unauthorized(new
            {
                Status = "Error",
                Message = "Incorrect Password"
            });
        }


        /// <summary>
        /// Password Change
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        /// <param name="_token"></param>
        /// <returns></returns>
        public async Task<IActionResult> ChangePasswordAsync(ClaimsIdentity identity, ChangePasswordDTO model)
        {
            // check if username exists
            var user = await _user.GetUserByIdAsync(identity);
            if (user == null)
                return NotFound(new { Status = "Error", Message = "Username Doesn't Exist!!" });

            // check if user exists
            if (await _userManager.CheckPasswordAsync(user, model.CurrentPassword))
            {
                var roles = await _userManager.GetRolesAsync(user);
                // change password
                if (model.NewPassword == model.ConfirmNewPassword)
                {
                    await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                }
                var token = await _token.CreateToken(user, roles, _roleManager);

                return Ok(new
                {
                    message = "Password Changed Successfully",
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized(new
            {
                Status = "Error",
                Message = "Incorrect Password"
            });
        }
    }
}
