namespace SmartRecruit.Application.DTO.Admin
{
    public record UserSearchRequest(
        string? SearchHeader = null,
        string? Role = null,
        bool? IsActive = null,
        int Page = 1,
        int PageSize = 10
    );
}
