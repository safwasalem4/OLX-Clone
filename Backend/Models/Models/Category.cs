using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public class Category : BaseModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<SubCategory> SubCategories { get; set; }

        public Category()
        {
            SubCategories = new List<SubCategory>();
        }
    }
}