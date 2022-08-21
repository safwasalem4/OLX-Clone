using Mapper.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using Services;
using Services.Contracts;
using System.Security.Claims;

namespace WepAPI.Controllers
{
    public class AccountController : APIBaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        { 
            _accountService = accountService;
        }

        // POST login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginDTO model)
        {
            return await _accountService.LoginAsync(model);

        }

        // POST register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync(RegisterDTO model)
        {
            return await _accountService.RegisterAsync(model);

        }

        // POST changePassword
        [Authorize]
        [HttpPost]
        [Route("changePassword")]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordDTO model)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            return await _accountService.ChangePasswordAsync(identity, model);

        }

    }
}
