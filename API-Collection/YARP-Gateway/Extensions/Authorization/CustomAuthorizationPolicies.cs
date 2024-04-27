using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace YARP_Gateway.Extensions.Authorization;

public static class CustomAuthorizationPolicies
{
    public static AuthorizationPolicy CreateJwtAuthorizationPolicy(string issuer, string authority)
    {
        var jwtPolicy = new AuthorizationPolicyBuilder()
            //.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
            .RequireAuthenticatedUser()
            // .RequireClaim("iss", issuer) // Require issuer claim to match the specified issuer
            // .RequireClaim("aud", authority) // Require audience claim to match the specified authority
            .Build();

        return jwtPolicy;
    }
}