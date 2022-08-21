using Data.Infrastructure;
using Data.Repositories.Contracts;
using Mapper.Contracts;
using Models.DTO;
using Models.Models;

namespace Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ISubCategoryService _subCategoryService;
        private readonly ILocationRepository _locationRepository;
        private readonly ILocationService _locationService;
        private readonly IPostMapper _postMapper;
        private readonly IUnitOfWork unitOfWork;

        public PostService(IPostRepository postRepository, ISubCategoryService subCategoryService, ILocationRepository locationRepository, ILocationService locationService, IPostMapper postMapper, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._subCategoryService = subCategoryService;
            this._locationRepository = locationRepository;
            this._locationService = locationService;
            this._postMapper = postMapper;
            this.unitOfWork = unitOfWork;
        }
        public PagedResult<PostDTO> GetAll(int PageNumber, int PageSize, string SortBy = "", string SortDirection = "")
        {
            List<string> Includes = new List<string>();
            Includes.Add("SubCategory");
            Includes.Add("User");
            Includes.Add("Location");
            PagedResult<Post> posts = _postRepository.GetAll(PageNumber, PageSize, Includes, SortBy, SortDirection);
            PagedResult<PostDTO> postDTOs = new PagedResult<PostDTO>();
            postDTOs.TotalRecords = posts.TotalRecords;
            postDTOs.Results = posts.Results.Select(x => _postMapper.MapToDTO(x)).ToList();
            return postDTOs;
        }

        public PostDTO GetById(int id)
        {
            Post post = _postRepository.GetById(id);
            PostDTO postDTO = _postMapper.MapToDTO(post);
            return postDTO;
        }
        public Post GetCategoryById(int id)
        {
            return _postRepository.GetById(id);
        }
        public PostDTO Add(PostDTO postDTO)
        {
            postDTO.CreatedAt = DateTime.UtcNow;
            Post post = _postMapper.MapFromDTO(postDTO);
            Post addedPost = _postRepository.Add(post);
            PostDTO result = _postMapper.MapToDTO(addedPost);
            return result;
        }
        public void Update(int id, PostDTO postDTO)
        {

            _postRepository.Update(id, _postMapper.MapFromDTO(postDTO));
        }
        public void Delete(int id)
        {
            Post post = _postRepository.GetById(id);
            _postRepository.Delete(post);
        }
        public bool PostExists(int id)
        {
            return _postRepository.IsExist(id);
        }
        public void SavePost()
        {
            unitOfWork.Commit();
        }
        public string Validate(PostDTO postDTO)
        {
            string error = "";
            if (postDTO.LocationId != null && !_locationService.LocationExists(postDTO.LocationId.Value))
            {
                error = "Location is required";
            }
            if (postDTO.SubCategoryId != null && !_subCategoryService.SubCategoryExists(postDTO.SubCategoryId.Value))
            {
                error = "SubCategory is required";
            }

            return error;
        }

        public PagedResult<PostDTO> GetAll(FilterDTO<PostDTO> filterObject)
        {
            List<string> Includes = new List<string>();
            Includes.Add("SubCategory");
            Includes.Add("User");
            Includes.Add("Location");
            Includes.Add("PostImages");
            filterObject.Includes = Includes;
            PagedResult<Post> posts = _postRepository.GetAll(filterObject);

            PagedResult<PostDTO> result = new PagedResult<PostDTO>();
            result.TotalRecords = posts.TotalRecords;
            result.Results = posts.Results.Select(x => _postMapper.MapToDTO(x)).ToList();

            return result;
        }
        public PagedResult<PostDTO> GetMyPosts(FilterDTO<PostDTO> filterObject)
        {
            List<string> Includes = new List<string>();
            Includes.Add("SubCategory");
            Includes.Add("User");
            Includes.Add("Location");
            Includes.Add("PostImages");

            filterObject.Includes = Includes;
            PagedResult<Post> posts = _postRepository.GetMyPosts(filterObject);

            PagedResult<PostDTO> result = new PagedResult<PostDTO>();
            result.TotalRecords = posts.TotalRecords;
            result.Results = posts.Results.Select(x => _postMapper.MapToDTO(x)).ToList();

            return result;
        }
    }
}
