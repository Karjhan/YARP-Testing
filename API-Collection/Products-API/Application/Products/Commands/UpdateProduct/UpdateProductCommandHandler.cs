using Commons.Exceptions;
using Commons.Primitives;
using Products_API.Domain.Abstractions;
using Reports_API.Application.Abstractions;

namespace Products_API.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : ICommandHandler<UpdateProductCommand>
{
    public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.ProductId, cancellationToken);
        
        if (product is null)
        {
            return Result.Failure(new Error(
                "Product.NotFound",
                $"The product with Id {request.ProductId} was not found"
            ));
        }
        
        product.Update(
            request.NewName,
            request.NewPrice,
            request.NewQuantity
        );
        productRepository.Update(product);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}