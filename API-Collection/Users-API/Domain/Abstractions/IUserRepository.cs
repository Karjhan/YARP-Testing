using Users_API.Domain.Entities;

namespace Users_API.Domain.Abstractions;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
    
    void Add(User user);

    void Update(User user);

    void Remove(User user);
}