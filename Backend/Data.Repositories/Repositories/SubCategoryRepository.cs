using Data.Infrastructure;
using Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Models.DTO;
using Models.Models;

namespace Data.Repositories.Repositories
{
    public class SubCategoryRepository : BaseRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<SubCategory> GetAllByCategoryId(int categoryId)
        {
            return this.DbContext.SubCategories.Where(c => c.CategoryID == categoryId);
        }
    }
}
