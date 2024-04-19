using AutoMapper;
using Commons.Exceptions;
using Commons.Primitives;
using Reports_API.Application.Abstractions;
using Reports_API.Application.Reports.DTOs;
using Reports_API.Domain.Abstractions;
using Reports_API.Domain.Entities;

namespace Reports_API.Application.Reports.Queries.GetReportById;

public class GetReportByIdQueryHandler(IReportRepository reportRepository, IMapper _mapper) : IQueryHandler<GetReportByIdQuery, ReportResponse>
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

        var response = _mapper.Map<Report, ReportResponse>(report);
        return response;
    }
}