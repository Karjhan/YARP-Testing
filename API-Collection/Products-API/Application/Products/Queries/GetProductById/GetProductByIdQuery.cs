using Products_API.Application.Products.DTOs;
using Reports_API.Application.Abstractions;

namespace Products_API.Application.Products.Queries.GetProductById;

public sealed record GetProductByIdQuery(Guid ProductId) : IQuery<ProductResponse>;