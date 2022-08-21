using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Services.Contracts;
using System.Security.Claims;

namespace WepAPI.Controllers
{

    [Authorize]
    public class UserPostsController : APIBaseController
    {
        private readonly IUserPostsService _posts;

        public UserPostsController(IUserPostsService posts)
        {
            _posts = posts;
        }

        [HttpGet]
        [Route("/getavailableposts")]
        public async Task<IActionResult> GetAvailabeUserPostsAsync()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            List<Post> posts = await _posts.GetUserAvailablePostsAsync(identity);
            return Ok(posts);
        }


        [HttpGet]
        [Route("/getunavailableposts")]
        public async Task<IActionResult> GetUnavailabeUserPostsAsync()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            List<Post> posts = await _posts.GetUserUnavailablePostsAsync(identity);
            return Ok(posts);
        }
    }
}
