using Data.Infrastructure;
using Data.Repositories.Contracts;
using Microsoft.AspNetCore.Identity;
using Models.Models;
using Services.Contracts;
using System.Security.Claims;

namespace Services.Services
{
    public class UserPostsService : IUserPostsService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPostRepository _posts;
        private readonly IUserService _user;

        public UserPostsService(UserManager<ApplicationUser> userManger, IPostRepository posts, IUserService user)
        {
            _userManager = userManger;
            _posts = posts;
            _user = user;
        }


        /// <summary>
        /// Get All user available posts
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public async Task<List<Post>> GetUserAvailablePostsAsync(ClaimsIdentity identity)
        {
            var user = await _user.GetUserByIdAsync(identity);
            List<Post> posts = _posts.GetAvailablePostsByUser(user.Id).ToList();
            return posts;
        }


        /// <summary>
        /// Get all user unavailble posts
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public async Task<List<Post>> GetUserUnavailablePostsAsync(ClaimsIdentity identity)
        {
            var user = await _user.GetUserByIdAsync(identity);
            List<Post> posts = _posts.GetUnavailablePostsByUser(user.Id).ToList();
            return posts;
        }


        //public async Task<Post> UpdateUserAvailablePostsAsync(Post post, int id)
        //{
        //    _posts.Update(id, post);
        //    return post;
        //}


    }
}
