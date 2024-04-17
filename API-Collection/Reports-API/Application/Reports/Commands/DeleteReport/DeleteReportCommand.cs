using Reports_API.Application.Abstractions;

namespace Reports_API.Application.Reports.Commands.DeleteReport;

public sealed record DeleteReportCommand(Guid ReportId) : ICommand;