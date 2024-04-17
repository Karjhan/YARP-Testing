using Reports_API.Application.Abstractions;

namespace Products_API.Application.Products.Commands.DeleteProduct;

public sealed record DeleteProductCommand(Guid ProductId) : ICommand;