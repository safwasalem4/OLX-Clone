using Data.Repositories.Contracts;
using Microsoft.AspNetCore.Identity;
using Models.Models;
using System.Security.Claims;


namespace Services.Contracts
{
    public interface IUserPostsService
    {
        public Task<List<Post>> GetUserAvailablePostsAsync(ClaimsIdentity identity);
        public Task<List<Post>> GetUserUnavailablePostsAsync(ClaimsIdentity identity);
    }
}
