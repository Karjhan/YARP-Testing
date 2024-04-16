using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Users_API.Domain.Abstractions;
using Users_API.Domain.Entities;

namespace Users_API.Infrastructure.DataContexts;

public class ApplicationContext : DbContext, IUnitOfWork
{
    public DbSet<User> Users { get; set; }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}