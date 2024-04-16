using Products_API.Application.Specifications.DTOs;

namespace Products_API.Application.Products.DTOs;

public sealed record ProductResponse(
    Guid Id,
    string Name, 
    decimal Price, 
    IEnumerable<SpecificationResponse> Specifications
);