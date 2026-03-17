namespace WebPortal.Models.Api.Admin
{
    public class UserSearchRequest
    {
        public string? SearchHeader { get; set; }
        public string? Role { get; set; }
        public bool? IsActive { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
