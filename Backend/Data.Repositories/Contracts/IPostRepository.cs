using Data.Infrastructure;
using Models.DTO;
using Models.Models;
using System.Linq.Expressions;

namespace Data.Repositories.Contracts
{
    public interface IPostRepository : IRepository<Post>
    {
        public Post GetById(int id);
        PagedResult<Post> GetMyPosts(FilterDTO<PostDTO> FilterObject);
        PagedResult<Post> GetAll(int PageNumber, int PageSize, List<string> includes, string SortBy, string SortDirection);
        PagedResult<Post> GetAll(FilterDTO<PostDTO> FilterObject);
        bool IsExist(int id);

        /// <summary>
        /// Get user posts by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<Post> GetAvailablePostsByUser(int id);

        /// <summary>
        /// Get the unavailable user posts
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<Post> GetUnavailablePostsByUser(int id);
    }
}
