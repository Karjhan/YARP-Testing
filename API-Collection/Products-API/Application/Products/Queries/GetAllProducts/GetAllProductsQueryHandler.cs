using Commons.Primitives;
using Products_API.Application.Abstractions;
using Products_API.Application.Products.DTOs;
using Products_API.Application.Specifications.DTOs;
using Products_API.Domain.Abstractions;

namespace Products_API.Application.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler(IProductRepository productRepository) : IQueryHandler<GetAllProductsQuery, IEnumerable<ProductResponse>>
{
    public async Task<Result<IEnumerable<ProductResponse>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var allProducts = await productRepository.GetAllAsync(cancellationToken);

        var response = allProducts.Select(product => new ProductResponse(
            product.Id, 
            product.Name, 
            product.Price, 
            product.Specifications.Select(spec => new SpecificationResponse(spec.Title, spec.Value))));

        return Result.Success(response);
    }
}