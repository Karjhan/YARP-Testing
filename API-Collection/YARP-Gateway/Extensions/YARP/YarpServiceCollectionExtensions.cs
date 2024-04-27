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
                handler.SslOptions.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            });

        return services;
    }
}