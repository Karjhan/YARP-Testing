using Commons.Exceptions;
using Commons.Primitives;
using Reports_API.Application.Abstractions;
using Reports_API.Domain.Abstractions;

namespace Reports_API.Application.Reports.Commands.UpdateReport;

public class UpdateReportCommandHandler(IReportRepository reportRepository, IUnitOfWork unitOfWork) : ICommandHandler<UpdateReportCommand>
{
    public async Task<Result> Handle(UpdateReportCommand request, CancellationToken cancellationToken)
    {
        var report = await reportRepository.GetByIdAsync(request.ReportId, cancellationToken);

        if (report is null)
        {
            return Result.Failure(new Error(
                "Report.NotFound",
                $"The report with Id {request.ReportId} was not found"
            ));
        }

        report.Update(
            request.NewTitle, 
            request.NewDescription);
        reportRepository.Update(report);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}