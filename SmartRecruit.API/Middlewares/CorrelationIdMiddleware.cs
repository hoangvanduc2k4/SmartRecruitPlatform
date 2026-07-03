using Serilog.Context;

namespace SmartRecruit.Middlewares
{
    public class CorrelationIdMiddleware
    {
        private readonly RequestDelegate _next;
        private const string CorrelationIdHeaderKey = "X-Correlation-ID";

        public CorrelationIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // 1. Get or generate Correlation ID
            if (!context.Request.Headers.TryGetValue(CorrelationIdHeaderKey, out var correlationId))
            {
                correlationId = Guid.NewGuid().ToString();
            }

            // 2. Add to response headers
            if (!context.Response.Headers.ContainsKey(CorrelationIdHeaderKey))
            {
                context.Response.Headers.Append(CorrelationIdHeaderKey, correlationId);
            }

            // 3. Push to Serilog LogContext
            using (LogContext.PushProperty("CorrelationId", correlationId.ToString()))
            {
                await _next(context);
            }
        }
    }
}
