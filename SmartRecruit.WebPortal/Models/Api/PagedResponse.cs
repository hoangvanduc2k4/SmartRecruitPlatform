namespace WebPortal.Models.Api
{
    public class PagedResponse<T> : ApiResponse<IEnumerable<T>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
