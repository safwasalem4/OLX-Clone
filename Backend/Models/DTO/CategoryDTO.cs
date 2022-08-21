using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class CategoryDTO
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<SubCategoryDTO> SubCategories { get; set; }

        public CategoryDTO()
        {
            SubCategories = new List<SubCategoryDTO>();
        }
    }
}
