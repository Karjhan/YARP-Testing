using Yarp.ReverseProxy.Transforms;

namespace YARP_Gateway.Extensions.YARP;

public static class YarpServiceCollectionExtensions
{
    public static IServiceCollection AddYARP(this IServiceCollection services, IConfiguration configuration)
    {
        // Add YARP from config
        services.AddReverseProxy()
            .LoadFromConfig(configuration.GetSection("Yarp.ReverseProxy"))
            .ConfigureHttpClient((context, handler) =>
            {
                handler.SslOptions.RemoteCertificateValidationCallback =
                    (sender, certificate, chain, sslPolicyErrors) => true;
            });
            // .AddTransforms(transformBuilderContext =>
            // {
            //     if (string.IsNullOrEmpty(transformBuilderContext.Route.AuthorizationPolicy))
            //     {
            //         transformBuilderContext.AddRequestTransform(requestTransformContext =>
            //         {
            //             var userDictionary = requestTransformContext.HttpContext.Request.Headers
            //             requestTransformContext.ProxyRequest.Headers.Add("X-User-Context",);
            //             return ValueTask.CompletedTask;
            //         });
            //     }
            // });

        return services;
    }
}