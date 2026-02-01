namespace SmartRecruit.Application.Wrappers
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public List<string> Errors { get; set; } = new();

        public ApiResponse() { }

        public static ApiResponse<T> Ok(T data, string message = "")
            => new ApiResponse<T> { Success = true, Data = data, Message = message };

        public static ApiResponse<T> Fail(string message, List<string>? errors = null)
            => new ApiResponse<T> { Success = false, Message = message, Errors = errors ?? new List<string>() };
    }

    public class ApiResponse : ApiResponse<object>
    {
        public static ApiResponse Ok(string message = "")
            => new ApiResponse { Success = true, Message = message };

        public static new ApiResponse Fail(string message, List<string>? errors = null)
            => new ApiResponse { Success = false, Message = message, Errors = errors ?? new List<string>() };
    }
}
