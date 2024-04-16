using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Products_API.Domain.Abstractions;
using Products_API.Domain.Entities;

namespace Products_API.Infrastructure.DataContexts;

public class ApplicationContext : DbContext, IUnitOfWork
{
    public DbSet<Product> Products { get; set; }
    
    public DbSet<Specification> Specifications { get; set; }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }    
}