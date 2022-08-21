using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public class Location : BaseModel
    {
        public int LocationId { set; get; }
        public string CityName { set; get; }
        public List<Post> Posts { set; get; }
        public Location()
        {
            Posts = new List<Post>();
        }
    }
}
