using Products_API.Domain.Entities;

namespace Products_API.Domain.Abstractions;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);
    
    void Add(Product product);

    void Update(Product product);

    void Remove(Product product);
}