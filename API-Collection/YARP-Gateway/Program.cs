using Serilog;
using YARP_Gateway.Extensions.Authorization;
using YARP_Gateway.Extensions.HealthCheck;
using YARP_Gateway.Extensions.Swagger;
using YARP_Gateway.Extensions.YARP;

var builder = WebApplication.CreateBuilder(args);

// Add logging with Serilog
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container
builder.Services.AddYARP(builder.Configuration);
builder.Services.AddHealthCheckServices();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddCustomAuthorization();
builder.Services.AddAuthentication();

var app = builder.Build();

if (app.Configuration.GetValue("EnforceHttpsRedirection", true))
{
    app.UseHttpsRedirection();
}

app.UseAuthentication();

app.UseAuthorization();

app.MapReverseProxy();

app.UseSerilogRequestLogging();

app.MapApplicationHealthChecks();

app.UseSwaggerDocumentation();

app.Run();

