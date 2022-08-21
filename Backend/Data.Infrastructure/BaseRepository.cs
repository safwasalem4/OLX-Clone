using Data.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;

namespace Data.Infrastructure
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        #region Properties
        private ApplicationDbContext dataContext;
        private readonly DbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected ApplicationDbContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }
        #endregion
        protected BaseRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        #region Implementation
        public virtual T Add(T entity)
        {

            return dbSet.Add(entity).Entity;
        }

        public virtual void Update(int id, T entity)
        {
            T local = dbSet.Find(id);
            if (local != null)
            {
                dataContext.Entry(local).State = EntityState.Detached;
            }

            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public virtual PagedResult<T> GetAll(int PageNumber, int PageSize, List<string> includes, string SortBy = "", string SortDirection = "")
        {
            PagedResult<T> PagedList = new PagedResult<T>();
            IQueryable<T> Query = dbSet.AsQueryable<T>();
            foreach (string include in includes)
            {
                Query = Query.Include(include);
            }

            string SortByParam = "CreatedAt";
            string SortDirectionParam = "ASC";

            if (!string.IsNullOrEmpty(SortBy))
            {
                SortByParam = SortBy;
            }
            if (!string.IsNullOrEmpty(SortDirection))
            {
                SortDirectionParam = SortDirection;
            }

            if (SortDirectionParam.ToLower() == "asc")
            {
                Query = Query.OrderBy(SortByParam);
            }
            else
            {
                Query = Query.OrderByDescending(SortByParam);
            }

            Query = Query.Take(PageSize);

            PagedList.Results = Query.Skip((PageNumber - 1) * PageSize).AsNoTracking().ToList();
            return PagedList;
        }
        #endregion
    }
}
