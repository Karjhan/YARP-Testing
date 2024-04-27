namespace YARP_Gateway.Extensions.Authorization;

public static class AuthorizationServiceCollectionExtensions
{
    public static IServiceCollection AddCustomAuthorization(this IServiceCollection services)
    {
        var issuer = "your_issuer_here"; 
        var authority = "your_authority_here"; 
        var jwtPolicy = CustomAuthorizationPolicies.CreateJwtAuthorizationPolicy(issuer, authority);
        services.AddAuthorization(options =>
        {
            options.AddPolicy("JWT_Policy", jwtPolicy);
        });

        return services;
    }
}