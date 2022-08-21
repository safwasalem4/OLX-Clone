using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Models.Models;

namespace Services
{

    public interface ITokenService
    {
        public Task<SecurityToken> CreateToken(ApplicationUser user, IList<string> roles,
            RoleManager<ApplicationRole> rolemanager);

    }
}
