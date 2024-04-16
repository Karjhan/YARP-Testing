using Products_API.Application.Abstractions;
using Products_API.Application.Specifications.DTOs;

namespace Products_API.Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand(
    Guid ProductId,
    string NewName,
    decimal NewPrice,
    int NewQuantity
) : ICommand;