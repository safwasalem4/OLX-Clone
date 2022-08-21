using Mapper.Contracts;
using Models.DTO;
using Models.Models;

namespace Mapper.Mappers
{
    public class SubCategoryMapper : ISubCategoryMapper
    {
        public SubCategory MapFromDTO(SubCategoryDTO subCategoryDTO)
        {
            SubCategory subCategory = new SubCategory();
            subCategory.SubCategoryID = subCategoryDTO.SubCategoryID;
            subCategory.SubCategoryName = subCategoryDTO.SubCategoryName;
            subCategory.CategoryID = subCategoryDTO.CategoryID;
            return subCategory;
        }

        public SubCategoryDTO MapToDTO(SubCategory subCategory)
        {
            SubCategoryDTO subCategoryDTO = new SubCategoryDTO();
            subCategoryDTO.SubCategoryID = subCategory.SubCategoryID;
            subCategoryDTO.SubCategoryName = subCategory.SubCategoryName;
            subCategoryDTO.CategoryID = subCategory.CategoryID;
            return subCategoryDTO;
        }
    }
}
