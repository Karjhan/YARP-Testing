using Commons.Exceptions;
using Commons.Primitives;
using Products_API.Domain.Abstractions;
using Reports_API.Application.Abstractions;

namespace Products_API.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : ICommandHandler<DeleteProductCommand>
{
    public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.ProductId, cancellationToken);
        
        if (product is null)
        {
            return Result.Failure(new Error(
                "Product.NotFound",
                $"The product with Id {request.ProductId} was not found"
            ));
        }

        productRepository.Remove(product);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}