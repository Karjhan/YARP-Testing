using Commons.Exceptions;
using Commons.Primitives;
using Reports_API.Application.Abstractions;
using Reports_API.Domain.Abstractions;

namespace Reports_API.Application.Reports.Commands.DeleteReport;

public class DeleteReportCommandHandler(IReportRepository reportRepository, IUnitOfWork unitOfWork) : ICommandHandler<DeleteReportCommand>
{
    public async Task<Result> Handle(DeleteReportCommand request, CancellationToken cancellationToken)
    {
        var report = await reportRepository.GetByIdAsync(request.ReportId, cancellationToken);

        if (report is null)
        {
            return Result.Failure(new Error(
                "Report.NotFound",
                $"The report with Id {request.ReportId} was not found"
            ));
        }

        reportRepository.Remove(report);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}