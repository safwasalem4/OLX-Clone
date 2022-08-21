using Models.DTO;
using Models.Models;

namespace Mapper.Contracts
{
    public interface ISubCategoryMapper
    {
        SubCategory MapFromDTO(SubCategoryDTO categoryDTO);
        SubCategoryDTO MapToDTO(SubCategory category);
    }
}
