using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace YARP_Gateway.Extensions.HealthCheck;

public class ApplicationHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.FromResult(HealthCheckResult.Healthy("Healthy"));
    }
}