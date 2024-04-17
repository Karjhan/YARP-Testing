using Reports_API.Application.Abstractions;

namespace Reports_API.Application.Reports.Commands.CreateReport;

public sealed record CreateReportCommand(
    string Title,
    string Description
) : ICommand;