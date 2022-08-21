using Mapper.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using Services;
using Services.Contracts;
using System.Security.Claims;

namespace WepAPI.Controllers
{
    [Authorize]
    public class PostsController : APIBaseController
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;

        public PostsController(IPostService postService, IUserService userService)
        {
            _postService = postService;
            _userService = userService;
        }

        // GET Posts/1
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_postService.PostExists(id))
            {
                return NotFound();
            }

            PostDTO postDTO = _postService.GetById(id);
            return Ok(postDTO);
        }

        // POST Posts
        [HttpPost]
        [Route("add")]
        public IActionResult Add(PostDTO postDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string ErrorMessage = _postService.Validate(postDTO);
            if (ErrorMessage != "")
            {
                return NotFound(ErrorMessage);
            }

            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
            Task<ApplicationUser> user = _userService.GetUserByIdAsync(identity);
            postDTO.UserID = user.Result.Id;

            PostDTO result = _postService.Add(postDTO);
            _postService.SavePost();
            return Ok(result);
        }

        // PUT Posts/1
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, PostDTO postDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != postDTO.PostId)
            {
                return BadRequest();
            }

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var user = await _userService.GetUserByIdAsync(identity);
            if (user.Id != postDTO.UserID)
            {
                return Unauthorized();
            }

            if (!_postService.PostExists(id))
            {
                return NotFound();
            }

            _postService.Update(id, postDTO);
            _postService.SavePost();
            PostDTO result = _postService.GetById(id);
            return Ok(result);
        }

        // DELETE Posts/1
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_postService.PostExists(id))
            {
                return NotFound();
            }
            PostDTO post = _postService.GetById(id);

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var user = await _userService.GetUserByIdAsync(identity);

            if (user.Id != post.UserID)
            {
                return Unauthorized();
            }

            _postService.Delete(id);
            _postService.SavePost();
            return Ok("Post deleted");
        }

        [HttpPost]
        [Route("")]
        public IActionResult GetAll(FilterDTO<PostDTO> filterObject)
        {
            //if no search is applied
            if (filterObject.SearchObject == null)
            {
                filterObject.SearchObject = new PostDTO();
            }
            PagedResult<PostDTO> postDTO = _postService.GetAll(filterObject);

            return Ok(postDTO);
        }

        [HttpPost]
        [Route("myPosts")]
        public async Task<IActionResult> GetMyPosts(FilterDTO<PostDTO> filterObject)
        {
            //if no search is applied
            if (filterObject.SearchObject == null)
            {
                filterObject.SearchObject = new PostDTO();
            }

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var user = await _userService.GetUserByIdAsync(identity);
            filterObject.SearchObject.UserID = user.Id;
            PagedResult<PostDTO> postDTO = _postService.GetMyPosts(filterObject);

            return Ok(postDTO);
        }
    }
}
