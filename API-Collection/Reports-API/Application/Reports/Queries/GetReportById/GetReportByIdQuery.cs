using Reports_API.Application.Abstractions;
using Reports_API.Application.Reports.DTOs;

namespace Reports_API.Application.Reports.Queries.GetReportById;

public record GetReportByIdQuery(Guid ReportId) : IQuery<ReportResponse>;