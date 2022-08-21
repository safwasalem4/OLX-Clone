using Microsoft.EntityFrameworkCore;

namespace Models.DTO
{
    public class PagedList<T> : List<T>
    {
        private Task<List<T>> items;
        private Task<int> count;
        private int pageNumber;

        public PagedList(IEnumerable<T> items, int count, int pageNumber, int pagesize)
        {
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pagesize);
            Pagesize = pagesize;
            TotalCount = count;
            AddRange(items);
        }

        public PagedList(Task<List<T>> items, Task<int> count, int pageNumber, int pagesize)
        {
            this.items = items;
            this.count = count;
            this.pageNumber = pageNumber;
            Pagesize = pagesize;
        }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int Pagesize { get; set; }
        public int TotalCount { get; set; }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pagesize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pagesize).Take(pagesize).ToListAsync();
            return new PagedList<T>(items, count, pageNumber, pagesize);
        }
    }
}
