using Carter;
using Commons.Middlewares;
using Microsoft.EntityFrameworkCore;
using Products_API.Application.Extensions;
using Products_API.Infrastructure.DataContexts;
using Products_API.Infrastructure.Extensions;
using Products_API.Presentation.Extensions;
using Products_API.Presentation.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add logging with Serilog
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddPresentationServices();
builder.Services.AddSwaggerDocumentation();

var app = builder.Build();

if (app.Configuration.GetValue("EnforceHttpsRedirection", true))
{
    app.UseHttpsRedirection();
}

app.UseMiddleware<RequestLogHeadersMiddleware>();

app.UseMiddleware<RequestLogContextMiddleware>();

app.UseSerilogRequestLogging();

app.MapApplicationHealthChecks();

app.UseSwaggerDocumentation();

app.MapCarter();

// Auto applying new migrations at build+run, or creating the DB otherwise
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationContext>();
    var logger = services.GetRequiredService<ILogger<Program>>();

    try
    {
        logger.LogInformation("Starting Context Initializer.");
        await context.Database.MigrateAsync();
    }
    catch (Exception e)
    {
        logger.LogInformation("An error occured during migration!");
    }
}

app.Run();

