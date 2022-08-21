using Models.DTO;
using Models.Models;

namespace Services
{
    public interface IPostService
    {
        PagedResult<PostDTO> GetAll(int PageNumber, int PageSize, string SortBy, string SortDirection);
        PostDTO GetById(int id);
        PostDTO Add(PostDTO postDTO);
        void Update(int id, PostDTO postDTO);
        void Delete(int id);
        bool PostExists(int id);
        void SavePost();
        string Validate(PostDTO postDTO);
        PagedResult<PostDTO> GetAll(FilterDTO<PostDTO> filterObject);
        PagedResult<PostDTO> GetMyPosts(FilterDTO<PostDTO> filterObject);
    }
}
