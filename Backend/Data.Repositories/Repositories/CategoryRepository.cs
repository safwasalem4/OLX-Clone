using Data.Infrastructure;
using Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace Data.Repositories.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Category> GetAllCategories()
        {
            IEnumerable<Category> result = this.DbContext.Categories.Include(x => x.SubCategories);
            return result;
        }

        public Category GetCategory(int id)
        {
            Category result = this.DbContext.Categories.Include(x => x.SubCategories).Select(category => category).FirstOrDefault(category => category.CategoryID == id);
            return result;
        }

        public bool IsExist(int id)
        {
            return this.DbContext.Categories.Any(category => category.CategoryID == id);
        }
    }
}
