using Mapper.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using Services.Contracts;
using System.Security.Claims;

namespace WepAPI.Controllers
{

    [Authorize]
    public class UserController : APIBaseController
    {
        private readonly IUserMapper _userMapper;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IUserMapper userMapper)
        {
            _userMapper = userMapper;
            _userService = userService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetUserDataAsync()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var user = await _userService.GetUserByIdAsync(identity);
            if (user != null)
            {
                var userDTO = _userMapper.MapToDTO(user);
                return Ok(userDTO);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUserDataAsync(UserDTO model)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var user = await _userService.UpdateUserAsync(identity, model);
            if (user != null)
            {
                var userDTO = _userMapper.MapToDTO(user);
                return StatusCode(StatusCodes.Status202Accepted, new { userDTO, message = "User Update Successfully" });
            }
            else
            {
                return NotFound();
            }
        }


        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteUserDataAsync()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var result = await _userService.DeleteUserAsync(identity);
            if (result.StatusCode == 204)
            {
                return StatusCode(StatusCodes.Status204NoContent, new { Message = "Deleted Successfully" });
            }
            else
            {
                return NotFound();
            }
        }
    }
}
