using AutoMapper;
using Commons.Primitives;
using Reports_API.Application.Abstractions;
using Reports_API.Application.Reports.DTOs;
using Reports_API.Domain.Abstractions;
using Reports_API.Domain.Entities;

namespace Reports_API.Application.Reports.Queries.GetAllReports;

public class GetAllReportsQueryHandler(IReportRepository reportRepository, IMapper _mapper) : IQueryHandler<GetAllReportsQuery, IEnumerable<ReportResponse>>
{
    public async Task<Result<IEnumerable<ReportResponse>>> Handle(GetAllReportsQuery request, CancellationToken cancellationToken)
    {
        var allReports = await reportRepository.GetAllAsync(cancellationToken);

        var response = _mapper.Map<IEnumerable<Report>, IEnumerable<ReportResponse>>(allReports);

        return Result.Success(response);
    }
}