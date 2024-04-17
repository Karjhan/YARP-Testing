using Carter;
using Microsoft.EntityFrameworkCore;
using Reports_API;
using Reports_API.Application.Extensions;
using Reports_API.Infrastructure.DataContexts;
using Reports_API.Infrastructure.Extensions;
using Reports_API.Presentation.Extensions;
using Reports_API.Presentation.Middlewares;
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

app.UseHttpsRedirection();

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