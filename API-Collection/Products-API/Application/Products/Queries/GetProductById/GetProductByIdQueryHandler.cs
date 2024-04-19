using AutoMapper;
using Commons.Exceptions;
using Commons.Primitives;
using Products_API.Application.Products.DTOs;
using Products_API.Domain.Abstractions;
using Products_API.Domain.Entities;
using Reports_API.Application.Abstractions;

namespace Products_API.Application.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler(IProductRepository productRepository, IMapper _mapper) : IQueryHandler<GetProductByIdQuery, ProductResponse>
{
    public async Task<Result<ProductResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.ProductId, cancellationToken);
        
        if (product is null)
        {
            return Result.Failure<ProductResponse>(new Error(
                "Product.NotFound",
                $"The product with Id {request.ProductId} was not found"
            ));
        }

        var response = _mapper.Map<Product, ProductResponse>(product);
        return response;
    }
}