namespace Models.DTO
{
    public class PagedResult<T> where T : class
    {
        public int TotalRecords { get; set; }
        public List<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }
    }
}
