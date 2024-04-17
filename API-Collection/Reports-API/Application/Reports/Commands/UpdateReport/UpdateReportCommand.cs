using Reports_API.Application.Abstractions;

namespace Reports_API.Application.Reports.Commands.UpdateReport;

public sealed record UpdateReportCommand(
    Guid ReportId,
    string NewTitle,
    string NewDescription
) : ICommand;