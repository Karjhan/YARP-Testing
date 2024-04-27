using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace YARP_Gateway.Extensions.HealthCheck;

public static class HealthCheckEndpointsExtensions
{
    public static IEndpointConventionBuilder MapApplicationHealthChecks(this IEndpointRouteBuilder endpoints)
    {
        // All
        var result = endpoints.MapHealthChecks("/healthCheck", new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        return result;
    }

    public static IServiceCollection AddHealthCheckServices(this IServiceCollection services)
    {
        // Add health checks
        services.AddHealthChecks()
            .AddCheck<ApplicationHealthCheck>("YARP-Gateway");

        return services;
    }
}