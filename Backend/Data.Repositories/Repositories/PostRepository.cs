using Data.Infrastructure.Extensions;
using Data.Infrastructure;
using Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Models.DTO;
using Models.Models;
using System.Linq.Expressions;

namespace Data.Repositories.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Post GetById(int id) => this.DbContext.Posts
            .Include(p => p.User)
            .Include(post => post.PostImages)
            .Include(l => l.Location)
            .Include(s => s.SubCategory)
            .FirstOrDefault(p => p.PostId == id);

        public PagedResult<Post> GetAll(
            int PageNumber,
            int PageSize,
            List<string> includes,
            Expression<Func<PostDTO, bool>> filter = null,
            string SortBy = "",
            string SortDirection = "",
            bool IsAvailable = true
            )
        {
            PagedResult<Post> posts = new PagedResult<Post>();
            if (SortBy.ToLower().Equals("price"))
            {
                if (SortDirection.ToLower().Equals("asc"))
                {
                    posts.Results = this.DbContext.Posts
                                        .Where(x => x.IsAvailable == IsAvailable)
                                        .Include(p => p.User)
                                        .Include(post => post.PostImages)
                                        .Include(l => l.Location)
                                        .Include(s => s.SubCategory)
                                        .OrderBy(on => on.Price)
                                        .Skip((PageNumber - 1) * PageSize)
                                        .Take(PageSize)
                                        .ToList();
                }
                else
                {
                    posts.Results = this.DbContext.Posts
                                        .Where(x => x.IsAvailable == IsAvailable)
                                        .Include(p => p.User)
                                        .Include(post => post.PostImages)
                                        .Include(l => l.Location)
                                        .Include(s => s.SubCategory)
                                        .OrderByDescending(on => on.Price)
                                        .Skip((PageNumber - 1) * PageSize)
                                        .Take(PageSize)
                                        .ToList();
                }

            }
            else
            {
                if (SortDirection.ToLower().Equals("asc"))
                {
                    posts.Results = this.DbContext.Posts
                                        .Where(x => x.IsAvailable == IsAvailable)
                                        .Include(p => p.User)
                                        .Include(post => post.PostImages)
                                        .Include(l => l.Location)
                                        .Include(s => s.SubCategory)
                                        .OrderBy(on => on.CreatedAt)
                                        .Skip((PageNumber - 1) * PageSize)
                                        .Take(PageSize)
                                        .ToList();
                }
                else
                {
                    posts.Results = this.DbContext.Posts
                                        .Where(x => x.IsAvailable == IsAvailable)
                                        .Include(p => p.User)
                                        .Include(post => post.PostImages)
                                        .Include(l => l.Location)
                                        .Include(s => s.SubCategory)
                                        .OrderByDescending(on => on.CreatedAt)
                                        .Skip((PageNumber - 1) * PageSize)
                                        .Take(PageSize)
                                        .ToList();
                }
            }

            posts.TotalRecords = posts.Results.Count();
            return posts;
        }

        public PagedResult<Post> GetAll(FilterDTO<PostDTO> FilterObject)
        {
            PagedResult<Post> posts = new PagedResult<Post>();
            Expression<Func<Post, bool>> SearchCriteria = a => (
            (a.Title.Contains(FilterObject.SearchObject.Title) || string.IsNullOrEmpty(FilterObject.SearchObject.Title))
            &&
            (a.Description.Contains(FilterObject.SearchObject.Description) || string.IsNullOrEmpty(FilterObject.SearchObject.Description))
            &&
            (a.UserID == FilterObject.SearchObject.UserID || FilterObject.SearchObject.UserID == 0 || FilterObject.SearchObject.UserID == null)
            &&
            (a.IsAvailable == true)
            &&
            (a.SubCategoryId == FilterObject.SearchObject.SubCategoryId || FilterObject.SearchObject.SubCategoryId == 0 || FilterObject.SearchObject.SubCategoryId == null)
            &&
            (a.LocationId == FilterObject.SearchObject.LocationId || FilterObject.SearchObject.LocationId == 0 || FilterObject.SearchObject.LocationId == null)
            &&
            (a.SubCategory.CategoryID == FilterObject.SearchObject.CategoryId || FilterObject.SearchObject.CategoryId == 0 || FilterObject.SearchObject.CategoryId == null)
            &&
            (a.Price >= FilterObject.SearchObject.minPrice || FilterObject.SearchObject.minPrice == 0 || FilterObject.SearchObject.minPrice == null)
            &&
            (a.Price <= FilterObject.SearchObject.maxPrice || FilterObject.SearchObject.maxPrice == 0 || FilterObject.SearchObject.maxPrice == null)
            );

            posts = this.GetAll(
                FilterObject.PageNumber,
                FilterObject.PageSize,
                FilterObject.Includes,
                SearchCriteria,
                FilterObject.SortBy,
                FilterObject.SortDirection
                );
            return posts;
        }

        public PagedResult<Post> GetMyPosts(FilterDTO<PostDTO> FilterObject)
        {
            PagedResult<Post> posts = new PagedResult<Post>();
            Expression<Func<Post, bool>> SearchCriteria = a => (
            (a.Title.Contains(FilterObject.SearchObject.Title) || string.IsNullOrEmpty(FilterObject.SearchObject.Title))
            &&
            (a.Description.Contains(FilterObject.SearchObject.Description) || string.IsNullOrEmpty(FilterObject.SearchObject.Description))
            &&
            (a.IsAvailable == FilterObject.SearchObject.IsAvailable || FilterObject.SearchObject.IsAvailable == null)
            &&
            (a.UserID == FilterObject.SearchObject.UserID || FilterObject.SearchObject.UserID == 0 || FilterObject.SearchObject.UserID == null)
            &&
            (a.SubCategoryId == FilterObject.SearchObject.SubCategoryId || FilterObject.SearchObject.SubCategoryId == 0 || FilterObject.SearchObject.SubCategoryId == null)
            &&
            (a.LocationId == FilterObject.SearchObject.LocationId || FilterObject.SearchObject.LocationId == 0 || FilterObject.SearchObject.LocationId == null)
            &&
            (a.SubCategory.CategoryID == FilterObject.SearchObject.CategoryId || FilterObject.SearchObject.CategoryId == 0 || FilterObject.SearchObject.CategoryId == null)
            &&
            (a.Price >= FilterObject.SearchObject.minPrice || FilterObject.SearchObject.minPrice == 0 || FilterObject.SearchObject.minPrice == null)
            &&
            (a.Price <= FilterObject.SearchObject.maxPrice || FilterObject.SearchObject.maxPrice == 0 || FilterObject.SearchObject.maxPrice == null)
            );

            posts = this.GetAll(
                FilterObject.PageNumber,
                FilterObject.PageSize,
                FilterObject.Includes,
                SearchCriteria,
                FilterObject.SortBy,
                FilterObject.SortDirection
                );
            return posts;
        }

        private PagedResult<Post> GetAll(
            int PageNumber,
            int PageSize,
            List<string> includes,
            Expression<Func<Post, bool>> filter = null,
            string SortBy = "",
            string SortDirection = ""
            )
        {
            PagedResult<Post> PagedList = new PagedResult<Post>();
            IQueryable<Post> Query = this.DbContext.Posts.AsQueryable<Post>();
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
            if (filter != null)
            {
                Query = Query.Where(filter);
            }

            PagedList.TotalRecords = Query.AsNoTracking().ToList().Count();

            if (SortDirectionParam.ToLower() == "asc")
            {
                Query = Query.OrderBy(SortByParam);
            }
            else
            {
                Query = Query.OrderByDescending(SortByParam);
            }

            Query = Query.Skip((PageNumber - 1) * PageSize);
            PagedList.Results = Query.Take(PageSize).AsNoTracking().ToList();

            return PagedList;
        }

        public bool IsExist(int id)
        {
            return this.DbContext.Posts.Any(post => post.PostId == id);
        }


        /// <summary>
        /// Get user posts by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Post> GetAvailablePostsByUser(int id)
        {
            return DbContext.Posts.Where(p => p.UserID == id && p.IsAvailable).ToList();
        }

        /// <summary>
        /// Get user unavailable posts
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Post> GetUnavailablePostsByUser(int id)
        {
            return DbContext.Posts.Where(p => p.UserID == id && p.IsAvailable == false).ToList();
        }
    }
}

