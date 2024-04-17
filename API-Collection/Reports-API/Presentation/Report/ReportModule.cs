using Carter;
using MediatR;
using Reports_API.Application.Reports.Commands.CreateReport;
using Reports_API.Application.Reports.Commands.DeleteReport;
using Reports_API.Application.Reports.Commands.UpdateReport;
using Reports_API.Application.Reports.Queries.GetAllReports;
using Reports_API.Application.Reports.Queries.GetReportById;
using Reports_API.Presentation.Report.DTOs;

namespace Reports_API.Presentation.Report;

public class ReportModule : CarterModule
{
    public ReportModule() : base("/reports")
    {
        
    }
    
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/", async (CreateReportRequest request, ISender sender) =>
        {
            CreateReportCommand command = request.ToCreateReportCommand();

            var result = await sender.Send(command);

            return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Error);
        });

        app.MapGet("/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            GetReportByIdQuery query = new GetReportByIdQuery(id);

            var response = await sender.Send(query, cancellationToken);

            return response.IsSuccess ? Results.Ok(response.Value) : Results.BadRequest(response.Error);
        });
        
        app.MapGet("/all", async (ISender sender, CancellationToken cancellationToken) =>
        {
            GetAllReportsQuery query = new GetAllReportsQuery();

            var response = await sender.Send(query, cancellationToken);

            return response.IsSuccess ? Results.Ok(response.Value) : Results.BadRequest(response.Error);
        });
        
        app.MapDelete("/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            DeleteReportCommand command = new DeleteReportCommand(id);

            var response = await sender.Send(command, cancellationToken);

            return response.IsSuccess ? Results.Ok() : Results.BadRequest(response.Error);
        });
        
        app.MapPut("/{id}", async (Guid id, UpdateReportRequest request, ISender sender, CancellationToken cancellationToken) =>
        {
            UpdateReportCommand command = new UpdateReportCommand(
                id,
                request.NewTitle,
                request.NewDescription
            );

            var response = await sender.Send(command, cancellationToken);

            return response.IsSuccess ? Results.Ok() : Results.BadRequest(response.Error);
        });
    }
}