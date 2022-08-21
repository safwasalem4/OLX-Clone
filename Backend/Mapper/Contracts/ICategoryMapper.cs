using Models.DTO;
using Models.Models;

namespace Mapper.Contracts
{
    public interface ICategoryMapper
    {
        Category MapFromDTO(CategoryDTO categoryDTO);
        CategoryDTO MapToDTO(Category category);
    }
}
