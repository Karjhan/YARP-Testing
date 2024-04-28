using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ILogger = Serilog.ILogger;

namespace Commons.Middlewares;

public class RequestLogHeadersMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLogHeadersMiddleware> _logger;

    public RequestLogHeadersMiddleware(RequestDelegate next, ILogger<RequestLogHeadersMiddleware> logger)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    
    public async Task Invoke(HttpContext context)
    {
        try
        {
            LogRequestHeaders(context.Request);
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in the RequestHeaderLoggingMiddleware.");
            throw;
        }
    }

    private void LogRequestHeaders(HttpRequest request)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("Incoming Request Headers:");
        foreach (var header in request.Headers)
        {
            stringBuilder.AppendLine($"{header.Key}: {header.Value}");
        }
        stringBuilder.AppendLine("End of Request Headers");
        _logger.LogInformation(stringBuilder.ToString());
    }
}