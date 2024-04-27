using System.Text.Json;
using Microsoft.Extensions.Primitives;
using Serilog;
using Serilog.Context;
using ILogger = Serilog.ILogger;

namespace Users_API.Presentation.Middlewares;

public class RequestLogContextMiddleware
{
    private const string CorrelationIdHeaderName = "X-Correlation-Id";
    private readonly RequestDelegate _next;

    public RequestLogContextMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task Invoke(HttpContext context, ILogger<RequestLogContextMiddleware> logger)
    {
        string correlationId = GetCorrelationId(context);
        
        logger.LogInformation(JsonSerializer.Serialize(context.Request.Headers));

        using (LogContext.PushProperty("CorrelationId", correlationId))
        {
            return _next.Invoke(context);
        }
    }

    private static string GetCorrelationId(HttpContext context)
    {
        context.Request.Headers.TryGetValue(
            CorrelationIdHeaderName, out StringValues correlationId);

        return correlationId.FirstOrDefault() ?? context.TraceIdentifier;
    }
}