using Microsoft.EntityFrameworkCore;
using Users_API.Domain.Abstractions;
using Users_API.Infrastructure.Configuration;
using Users_API.Infrastructure.DataContexts;
using Users_API.Infrastructure.HealthChecks;
using Users_API.Infrastructure.Repositories;

namespace Users_API.Infrastructure.Extensions;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Add EF Core configuration
        services.Configure<EFConfiguration>(configuration.GetSection(nameof(EFConfiguration)).Bind);

        var efConfiguration = configuration.GetSection(nameof(EFConfiguration)).Get<EFConfiguration>();
        
        // Add health checks
        services.AddHealthChecks()
            .AddCheck<ApplicationHealthCheck>("Users-API")
            .AddNpgSql(efConfiguration!.ConnectionString);
        
        // Add entity dbContext for app, add postgres connection for dbContext
        services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseNpgsql(efConfiguration.ConnectionString);
        });
        
        // Add services for dependency injection
        services.AddScoped<IUnitOfWork>(sp =>
            sp.GetRequiredService<ApplicationContext>());
        services.AddScoped<IUserRepository, UserRepository>();
        
        // Add CORS
        services.AddCors(options =>
        {
            options.AddPolicy("DefaultCorsPolicy", policy =>
            {
                var origins = configuration.GetSection("AllowedOrigins").Get<string[]>();
                if (origins?.Length > 0)
                {
                    policy
                        .WithOrigins(origins)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                }
                else
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                }
            });
        });
        
        return services;
    }
}