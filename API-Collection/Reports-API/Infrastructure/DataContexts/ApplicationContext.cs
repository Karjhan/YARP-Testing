using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Reports_API.Domain.Abstractions;
using Reports_API.Domain.Entities;

namespace Reports_API.Infrastructure.DataContexts;

public class ApplicationContext : DbContext, IUnitOfWork
{
    public DbSet<Report> Reports { get; set; }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }    
}