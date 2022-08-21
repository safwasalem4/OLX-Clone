using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public class PostImage : BaseModel
    {
        public int PostImageID { get; set; }
        public string ImageURL { get; set; }
        public int PostId { set; get; }
        public Post Post { get; set; }

    }
}
