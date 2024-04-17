using Commons.Primitives;
using Reports_API.Application.Abstractions;
using Reports_API.Application.Reports.DTOs;
using Reports_API.Domain.Abstractions;

namespace Reports_API.Application.Reports.Queries.GetAllReports;

public class GetAllReportsQueryHandler(IReportRepository reportRepository) : IQueryHandler<GetAllReportsQuery, IEnumerable<ReportResponse>>
{
    public async Task<Result<IEnumerable<ReportResponse>>> Handle(GetAllReportsQuery request, CancellationToken cancellationToken)
    {
        var allReports = await reportRepository.GetAllAsync(cancellationToken);

        var response = allReports.Select(report => new ReportResponse(report.Id, report.Title, report.Description));

        return Result.Success(response);
    }
}