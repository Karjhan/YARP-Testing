using Reports_API.Domain.Entities;

namespace Reports_API.Domain.Abstractions;

public interface IReportRepository
{
    Task<Report?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<List<Report>> GetAllAsync(CancellationToken cancellationToken);
    
    void Add(Report report);

    void Update(Report report);

    void Remove(Report report);
}