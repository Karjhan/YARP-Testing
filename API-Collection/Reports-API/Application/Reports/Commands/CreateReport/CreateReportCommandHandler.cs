using Commons.Primitives;
using Reports_API.Application.Abstractions;
using Reports_API.Domain.Abstractions;
using Reports_API.Domain.Entities;

namespace Reports_API.Application.Reports.Commands.CreateReport;

public class CreateReportCommandHandler(IReportRepository reportRepository, IUnitOfWork unitOfWork) : ICommandHandler<CreateReportCommand>
{
    public async Task<Result> Handle(CreateReportCommand request, CancellationToken cancellationToken)
    {
        Guid userId = Guid.NewGuid();

        Report newReport = Report.Create(userId, request.Title, request.Description);
        reportRepository.Add(newReport);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}