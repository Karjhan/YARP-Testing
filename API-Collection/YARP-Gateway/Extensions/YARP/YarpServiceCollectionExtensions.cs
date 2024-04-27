using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using Yarp.ReverseProxy.Transforms;

namespace YARP_Gateway.Extensions.YARP;

public static class YarpServiceCollectionExtensions
{
    public static IServiceCollection AddYARP(this IServiceCollection services, IConfiguration configuration)
    {
        // Add YARP from config
        services.AddReverseProxy()
            .LoadFromConfig(configuration.GetSection("ReverseProxy"))
            .ConfigureHttpClient((context, handler) =>
            {
                handler.SslOptions.RemoteCertificateValidationCallback =
                    (sender, certificate, chain, sslPolicyErrors) => true;
            })
            .AddTransforms(transformBuilderContext =>
            {
                if (!string.IsNullOrEmpty(transformBuilderContext.Route.AuthorizationPolicy))
                {
                    transformBuilderContext.AddRequestTransform(requestTransformContext =>
                    {
                        var authorizationHeader = requestTransformContext.HttpContext.Request.Headers["Authorization"].ToString();
                        
                        if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                        {
                            string token = authorizationHeader.Substring("Bearer ".Length).Trim();

                            var handler = new JwtSecurityTokenHandler();
                            var jwtToken = handler.ReadToken(token) as JwtSecurityToken;
                            var username = jwtToken?.Claims.First(claim => claim.Type == "username").Value;
                            
                            if (!string.IsNullOrEmpty(username))
                            {
                                requestTransformContext.ProxyRequest.Headers.Remove("Authorization");
                                requestTransformContext.ProxyRequest.Headers.TryAddWithoutValidation("X-User-Context", username);
                            }
                        }
                        return ValueTask.CompletedTask;
                    });
                }
            });

        return services;
    }
}