using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public class Post : BaseModel
    {
        public int PostId { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public DateTime CreatedAt { set; get; }
        public double Price { set; get; }
        public bool IsNew { set; get; }
        public bool IsNegotiable { set; get; }
        public bool IsAvailable { get; set; } // tbd
        public int SubCategoryId { set; get; }
        public SubCategory SubCategory { set; get; }
        public int UserID { set; get; }
        public ApplicationUser User { set; get; }
        public int LocationId { set; get; }
        public Location Location { set; get; }
        public List<PostImage> PostImages { set; get; }
        public Post()
        {
            PostImages = new List<PostImage>();
        }
    }
}
