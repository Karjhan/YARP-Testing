using Commons.Primitives;
using Products_API.Application.Abstractions;
using Products_API.Domain.Abstractions;
using Products_API.Domain.Entities;

namespace Products_API.Application.Products.CreateProduct;

public class CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : ICommandHandler<CreateProductCommand>
{
    public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Guid productId = Guid.NewGuid();
        IEnumerable<Specification> specifications =
            request.Specifications.Select(spec => Specification.Create(productId, spec.Title, spec.Value));

        Product newProduct = Product.Create(
            productId, 
            request.Name, 
            request.Price, 
            request.Quantity,
            specifications);
        productRepository.Add(newProduct);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}