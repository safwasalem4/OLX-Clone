namespace Models.DTO
{
    public class FilterDTO<T> where T : class
    {
        public T SearchObject { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortDirection { get; set; }
        public List<string> Includes { get; set; }

        public FilterDTO()
        {
            Includes = new List<string>();
        }
    }
}
