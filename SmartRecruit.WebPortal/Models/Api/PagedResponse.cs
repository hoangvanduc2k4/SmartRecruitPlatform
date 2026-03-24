namespace WebPortal.Models.Api
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
    }
}
