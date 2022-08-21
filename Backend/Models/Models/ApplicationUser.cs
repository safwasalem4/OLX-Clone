using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public interface Base
    {
        public class Base : BaseModel
        {
        }
    }
    public class ApplicationUser:IdentityUser<int>, Base
    {
        [MaxLength(200)]
        public string? AboutMe { get; set; }
        public string FName { set; get; }
        public string LName { set; get; }
        public List<Post> Posts { get; set; }

        public ApplicationUser()
        {
            Posts = new List<Post>();
        }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
