using MediatR.NotificationPublishers;

namespace Reports_API.Application.Extensions;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Add MediatR
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<Program>();

            config.NotificationPublisher = new TaskWhenAllPublisher();
        });
        
        return services;
    }    
}