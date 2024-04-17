using Reports_API.Application.Abstractions;

namespace Products_API.Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand(
    Guid ProductId,
    string NewName,
    decimal NewPrice,
    int NewQuantity
) : ICommand;