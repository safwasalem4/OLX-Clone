using Models.Models;

namespace Models.DTO
{
    public class PostDTO
    {
        public int PostId { set; get; }
        public string? Title { set; get; }
        public string? Description { set; get; }
        public DateTime CreatedAt { set; get; }
        public double Price { set; get; }
        public bool IsNew { set; get; }
        public bool IsNegotiable { set; get; }
        public bool? IsAvailable { get; set; }
        public int? SubCategoryId { set; get; }
        public int? LocationId { set; get; }
        public int? UserID { set; get; }
        public string? SubCategoryName { set; get; }
        public string? CityName { set; get; }
        public string? FullName { set; get; }
        public string? PhoneNumber { set; get; }
        public string? AboutMe { set; get; }
        public int? minPrice { get; set; }
        public int? maxPrice { get; set; }
        public int? CategoryId { get; set; }
        public List<PostImageDTO> PostImages { set; get; }

        public PostDTO()
        {
            PostImages = new List<PostImageDTO>();
        }
    }
}
