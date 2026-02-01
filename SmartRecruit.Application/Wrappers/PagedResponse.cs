namespace SmartRecruit.Application.Wrappers
{
    public class PagedResponse<T> : ApiResponse<IEnumerable<T>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }

        public PagedResponse() { }
        public static PagedResponse<T> Create(
            IEnumerable<T> items,
            int page,
            int pageSize,
            int totalCount,
            string message = "")
        {
            var totalPages = pageSize > 0 ? (int)Math.Ceiling(totalCount / (double)pageSize) : 0;

            return new PagedResponse<T>
            {
                Success = true,
                Message = message,
                Data = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = totalPages
            };
        }
    }
}
