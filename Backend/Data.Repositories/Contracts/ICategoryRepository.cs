using Data.Infrastructure;
using Models.Models;

namespace Data.Repositories.Contracts
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategory(int id);
        bool IsExist(int id);
    }
}
