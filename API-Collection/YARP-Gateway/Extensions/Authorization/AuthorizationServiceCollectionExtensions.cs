using Microsoft.AspNetCore.Authentication.JwtBearer;
using YARP_Gateway.Models;

namespace YARP_Gateway.Extensions.Authorization;

public static class AuthorizationServiceCollectionExtensions
{
    public static IServiceCollection AddCustomSecurity(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<IdentityServerConfiguration>(configuration.GetSection(nameof(IdentityServerConfiguration)).Bind);
        var identityConfiguration = configuration.GetSection(nameof(IdentityServerConfiguration)).Get<IdentityServerConfiguration>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = identityConfiguration!.IdentityUrl;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters.ValidateIssuer = true;
                options.TokenValidationParameters.ValidateAudience = false;
                options.TokenValidationParameters.NameClaimType = "username";
                options.TokenValidationParameters.ValidateLifetime = true;
            });
        
        services.AddAuthorization(options =>
        {
            options.AddPolicy("JWT_Policy", policy =>
            {
                policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                policy.RequireAuthenticatedUser();
            });
        });

        return services;
    }
}