using AutoMapper;
using Commons.Primitives;
using Products_API.Application.Products.DTOs;
using Products_API.Domain.Abstractions;
using Products_API.Domain.Entities;
using Reports_API.Application.Abstractions;

namespace Products_API.Application.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler(IProductRepository productRepository, IMapper _mapper) : IQueryHandler<GetAllProductsQuery, IEnumerable<ProductResponse>>
{
    public async Task<Result<IEnumerable<ProductResponse>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var allProducts = await productRepository.GetAllAsync(cancellationToken);

        var response = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResponse>>(allProducts);

        return Result.Success(response);
    }
}