using Microsoft.AspNetCore.Identity;

namespace Models.Models
{
    public class ApplicationUserRole : IdentityUserRole<int>
    {
        public ApplicationUser User { get; set; }
        public ApplicationRole Role { get; set; }

    }
}
