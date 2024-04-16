using Products_API.Application.Abstractions;
using Products_API.Application.Specifications.DTOs;
using Products_API.Domain.Entities;

namespace Products_API.Application.Products.CreateProduct;

public sealed record CreateProductCommand(
    string Name,
    decimal Price,
    int Quantity,
    IEnumerable<SpecificationResponse> Specifications
) : ICommand;