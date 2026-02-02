using SmartRecruit.Application.Wrappers;
using SmartRecruit.Application.Helpers;

namespace SmartRecruit.Application.Extensions
{
    public static class ResponseExtensions
    {
        public static ApiResponse<T> Wrap<T>(this T data, string message = "")
        {
            return ApiResponse<T>.Ok(data, message);
        }
        
        public static PagedResponse<T> WrapPaged<T>(this PagedList<T> data, string message = "")
        {
            return PagedResponse<T>.Create(data, data.CurrentPage, data.PageSize, data.TotalCount, message);
        }

        public static ApiResponse ToFailedResponse(this Exception ex)
        {
             return ApiResponse.Fail(ex.Message);
        }
    }
}
