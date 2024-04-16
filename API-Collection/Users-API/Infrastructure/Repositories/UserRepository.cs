using Microsoft.EntityFrameworkCore;
using Users_API.Domain.Abstractions;
using Users_API.Domain.Entities;
using Users_API.Infrastructure.DataContexts;

namespace Users_API.Infrastructure.Repositories;

public class UserRepository(ApplicationContext context) : IUserRepository
{
    public Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return context.Users.SingleOrDefaultAsync(user => user.Id == id, cancellationToken);
    }

    public Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return context.Users.ToListAsync(cancellationToken);
    }

    public void Add(User user)
    {
        context.Users.Add(user);
    }

    public void Update(User user)
    {
        context.Users.Update(user);
    }

    public void Remove(User user)
    {
        context.Users.Remove(user);
    }
}