namespace SmartRecruit.Application.Wrappers
{
    public class PagedResponse<T> : ApiResponse<IEnumerable<T>>
    {
        [System.Text.Json.Serialization.JsonPropertyName("page")]
        public int Page { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalPages")]
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
