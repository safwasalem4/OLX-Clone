using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Services.Contracts;
using System.Net.Http.Headers;

namespace WepAPI.Controllers
{
    [Authorize]
    public class PostImageController : APIBaseController
    {
        private readonly IPostImageService _postimageService;


        public PostImageController(IPostImageService postimageService)
        {
            _postimageService = postimageService;
        }

        // GET Images
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            IEnumerable<PostImageDTO> postimageDTO = _postimageService.GetAll();
            return Ok(postimageDTO);
        }
        // GET Images
        [HttpGet]
        [Route("getallbyid/{id}")]
        public IActionResult GetAll(int id)
        {
            IEnumerable<PostImageDTO> postimageDTO = _postimageService.GetAll(id);
            return Ok(postimageDTO);
        }

        // GET post image with id
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_postimageService.ImageExists(id))
            {
                return NotFound();
            }

            PostImageDTO postimageDTO = _postimageService.GetById(id);
            return Ok(postimageDTO);
        }

        // POST PostImage
        [HttpPost]
        [Route("{id}")]
        public IActionResult Add(int id, List<string> dbPath)
        {
            //id here stands for post id
            IEnumerable<PostImageDTO> postimagesDTO = Enumerable.Empty<PostImageDTO>();
            foreach (var path in dbPath)
            {
                PostImageDTO postimageDTO = new PostImageDTO();
                postimageDTO.PostId = id;
                postimageDTO.ImageURL = path;
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _postimageService.Add(postimageDTO);
                postimagesDTO.Append(postimageDTO);
            }
            _postimageService.SavePostImage();
            return Ok(postimagesDTO);
        }
        [HttpPost]
        [Route("")]
        public IActionResult Add(PostImageDTO postimageDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _postimageService.Add(postimageDTO);
            _postimageService.SavePostImage();
            return Ok(postimageDTO);
        }

        // PUT PostImage
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, PostImageDTO postimageDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != postimageDTO.PostImageID)
            {
                return BadRequest();
            }

            if (!_postimageService.ImageExists(id))
            {
                return NotFound();
            }

            _postimageService.Update(id, postimageDTO);
            _postimageService.SavePostImage();
            return Ok(postimageDTO);
        }

        // DELETE /1
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_postimageService.ImageExists(id))
            {
                return NotFound();
            }
            _postimageService.Delete(id);
            _postimageService.SavePostImage();
            return Ok("Post Image deleted");
        }
        [HttpPost, DisableRequestSizeLimit]
        [Route("upload")]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var files = formCollection.Files;
                if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                }
                if (files.Count > 5)
                {
                    return BadRequest("Upload limit is 5 images per post");
                }
                var dbPaths = _postimageService.Upload(files);
                return Ok(new { dbPaths });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }



    }
}
