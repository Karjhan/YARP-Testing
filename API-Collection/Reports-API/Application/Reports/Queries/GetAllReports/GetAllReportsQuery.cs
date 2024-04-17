using Reports_API.Application.Abstractions;
using Reports_API.Application.Reports.DTOs;

namespace Reports_API.Application.Reports.Queries.GetAllReports;

public sealed record GetAllReportsQuery() : IQuery<IEnumerable<ReportResponse>>;