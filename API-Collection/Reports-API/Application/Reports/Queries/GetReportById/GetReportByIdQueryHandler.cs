using Commons.Exceptions;
using Commons.Primitives;
using Reports_API.Application.Abstractions;
using Reports_API.Application.Reports.DTOs;
using Reports_API.Domain.Abstractions;

namespace Reports_API.Application.Reports.Queries.GetReportById;

public class GetReportByIdQueryHandler(IReportRepository reportRepository) : IQueryHandler<GetReportByIdQuery, ReportResponse>
{
    public async Task<Result<ReportResponse>> Handle(GetReportByIdQuery request, CancellationToken cancellationToken)
    {
        var report = await reportRepository.GetByIdAsync(request.ReportId, cancellationToken);

        if (report is null)
        {
            return Result.Failure<ReportResponse>(new Error(
                "Report.NotFound",
                $"The report with Id {request.ReportId} was not found"
            ));
        }

        var response = new ReportResponse(report.Id, report.Title, report.Description);
        return response;
    }
}