using Data.Infrastructure;
using Models.Models;

namespace Data.Repositories.Contracts
{
    public interface ISubCategoryRepository : IRepository<SubCategory>
    {
        IEnumerable<SubCategory> GetAllByCategoryId(int categoryId);
    }
}
