using Products_API.Application.Abstractions;
using Products_API.Application.Products.DTOs;

namespace Products_API.Application.Products.Queries.GetAllProducts;

public sealed record GetAllProductsQuery : IQuery<IEnumerable<ProductResponse>>
{
    
}