using Products_API.Application.Abstractions;
using Products_API.Application.Products.DTOs;

namespace Products_API.Application.Products.Queries.GetProductById;

public sealed record GetProductByIdQuery(Guid ProductId) : IQuery<ProductResponse>;