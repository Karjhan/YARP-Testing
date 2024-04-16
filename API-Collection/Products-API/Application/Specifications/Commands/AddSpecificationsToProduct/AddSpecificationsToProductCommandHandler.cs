using Commons.Exceptions;
using Commons.Primitives;
using Products_API.Application.Abstractions;
using Products_API.Domain.Abstractions;

namespace Products_API.Application.Specifications.Commands.AddSpecificationsToProduct;

public class AddSpecificationsToProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : ICommandHandler<AddSpecificationsToProductCommand>
{
    public async Task<Result> Handle(AddSpecificationsToProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.ProductId, cancellationToken);
        
        if (product is null)
        {
            return Result.Failure(new Error(
                "Product.NotFound",
                $"The product with Id {request.ProductId} was not found"
            ));
        }

        foreach (var spec in request.Specifications)
        {
            product.AddOrUpdateSpecification(spec);
        }
        productRepository.Update(product);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}