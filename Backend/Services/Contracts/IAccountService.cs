
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using Services.Contracts;
using System.Security.Claims;

namespace Services
{
    public interface IAccountService
    {
        public Task<IActionResult> RegisterAsync(RegisterDTO model);

        public Task<IActionResult> LoginAsync(LoginDTO model);

        public Task<IActionResult> ChangePasswordAsync(ClaimsIdentity identity, ChangePasswordDTO model);

    }
}
