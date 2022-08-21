using Microsoft.AspNetCore.Identity;

namespace Models.Models
{
    public class ApplicationRole : IdentityRole<int>
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
