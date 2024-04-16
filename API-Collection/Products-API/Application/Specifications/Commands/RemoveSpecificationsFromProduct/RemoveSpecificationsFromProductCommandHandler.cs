using Commons.Exceptions;
using Commons.Primitives;
using Products_API.Application.Abstractions;
using Products_API.Domain.Abstractions;

namespace Products_API.Application.Specifications.Commands.RemoveSpecificationsFromProduct;

public class RemoveSpecificationsFromProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : ICommandHandler<RemoveSpecificationsFromProductCommand>
{
    public async Task<Result> Handle(RemoveSpecificationsFromProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.ProductId, cancellationToken);
        
        if (product is null)
        {
            return Result.Failure(new Error(
                "Product.NotFound",
                $"The product with Id {request.ProductId} was not found"
            ));
        }

        int index = 0;
        while (index < product.Specifications.Count)
        {
            var spec = product.Specifications[index];
            if (request.SpecificationTitles.Contains(spec.Title))
            {
                product.Specifications.RemoveAt(index);
            }
            else
            {
                index++;
            }
        }
        productRepository.Update(product);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}