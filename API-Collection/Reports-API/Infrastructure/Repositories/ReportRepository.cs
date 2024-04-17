using Microsoft.EntityFrameworkCore;
using Reports_API.Domain.Abstractions;
using Reports_API.Domain.Entities;
using Reports_API.Infrastructure.DataContexts;

namespace Reports_API.Infrastructure.Repositories;

public class ReportRepository(ApplicationContext context) : IReportRepository
{
    public Task<Report?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return context.Reports.SingleOrDefaultAsync(report => report.Id == id, cancellationToken);
    }

    public Task<List<Report>> GetAllAsync(CancellationToken cancellationToken)
    {
        return context.Reports.ToListAsync(cancellationToken);
    }

    public void Add(Report report)
    {
        context.Reports.Add(report);
    }

    public void Update(Report report)
    {
        context.Reports.Update(report);
    }

    public void Remove(Report report)
    {
        context.Reports.Remove(report);
    }
}