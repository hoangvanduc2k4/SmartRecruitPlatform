using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;
using SmartRecruit.Application.Wrappers;
using SmartRecruit.Domain.Exceptions;

namespace SmartRecruit.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = ApiResponse.Fail(error.Message);

                _logger.LogWarning("ErrorHandlerMiddleware caught exception: {Type} - {Message}", error.GetType().Name, error.Message);

                switch (error)
                {
                    case FluentValidation.ValidationException e:
                        // validation error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Message = "Dữ liệu không hợp lệ."; 
                        responseModel.Errors = e.Errors.Select(x => x.ErrorMessage).ToList();
                        break;
                    case KeyNotFoundException:
                    case NotFoundException:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case ArgumentException:
                    case InvalidOperationException:
                    case BadRequestException:
                        // bad request error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case UnauthorizedAccessException e:
                        // unauthorized error
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                    case DbUpdateException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Message = e.InnerException?.Message ?? e.Message;
                        break;
                    default:
                        // unhandled error
                        _logger.LogError(error, error.Message);
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                _logger.LogInformation("Returning error response: {StatusCode} - {Message}", response.StatusCode, responseModel.Message);


                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}
