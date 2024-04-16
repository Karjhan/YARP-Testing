using Microsoft.EntityFrameworkCore;
using Products_API.Domain.Abstractions;
using Products_API.Domain.Entities;
using Products_API.Infrastructure.DataContexts;

namespace Products_API.Infrastructure.Repositories;

public class ProductRepository(ApplicationContext context) : IProductRepository
{
    public Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return context.Products
            .Include(product => product.Specifications)
            .SingleOrDefaultAsync(product => product.Id == id, cancellationToken);
    }

    public Task<List<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        return context.Products
            .Include(product => product.Specifications)
            .ToListAsync(cancellationToken);
    }

    public void Add(Product product)
    {
        context.Products.Add(product);
    }

    public void Update(Product product)
    {
        context.Products.Update(product);
    }

    public void Remove(Product product)
    {
        context.Products.Remove(product);
    }
}