using Models.DTO;
using Models.Models;

namespace Services
{
    public interface ISubCategoryService
    {
        IEnumerable<SubCategoryDTO> GetAllByCategoryId(int id);
        SubCategoryDTO GetById(int id);
        SubCategory GetSubCategoryById(int id);
        SubCategoryDTO Add(SubCategoryDTO subCategoryDTO);
        void Update(int id, SubCategoryDTO subCategoryDTO);
        void Delete(int id);
        bool SubCategoryExists(int id);
        void SaveSubCategory();
    }
}
