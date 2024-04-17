using Products_API.Application.Specifications.DTOs;
using Reports_API.Application.Abstractions;

namespace Products_API.Application.Products.CreateProduct;

public sealed record CreateProductCommand(
    string Name,
    decimal Price,
    int Quantity,
    IEnumerable<SpecificationResponse> Specifications
) : ICommand;