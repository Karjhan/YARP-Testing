using Commons.Primitives;
using Products_API.Application.Specifications.DTOs;

namespace Products_API.Domain.Entities;

public class Product(Guid id) : Entity(id)
{
    public string Name { get; private set; }

    public decimal Price { get; private set; }

    public int Quantity { get; private set; }

    public List<Specification> Specifications { get; } = new List<Specification>();

    public Product(
        Guid id, 
        string name, 
        decimal price, 
        int quantity) : this(id)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
    
    public static Product Create(
        Guid id,
        string name,
        decimal price,
        int quantity,
        IEnumerable<Specification> specifications)
    {
        Product product = new Product(
            id, 
            name, 
            price,
            quantity
        );
        product.Specifications.AddRange(specifications);

        return product;
    }
    
    public void Update(string newName, decimal newPrice, int newQuantity)
    {
        Name = newName;
        Price = newPrice;
        Quantity = newQuantity;
    }
    
    public void AddOrUpdateSpecification(SpecificationResponse specification)
    {
        Specification? existingSpec = Specifications.FirstOrDefault(spec => spec.Title == specification.Title);
        
        if (existingSpec != null)
        {
            Specifications.Remove(existingSpec);
        }
        
        Specifications.Add(Specification.Create(Id, specification.Title, specification.Value));
    }
}