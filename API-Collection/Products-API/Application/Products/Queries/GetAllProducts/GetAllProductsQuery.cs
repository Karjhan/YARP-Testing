using Products_API.Application.Products.DTOs;
using Reports_API.Application.Abstractions;

namespace Products_API.Application.Products.Queries.GetAllProducts;

public sealed record GetAllProductsQuery : IQuery<IEnumerable<ProductResponse>>
{
    
}