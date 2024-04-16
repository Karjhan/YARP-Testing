using Carter;
using MediatR;
using Products_API.Application.Products.Commands.DeleteProduct;
using Products_API.Application.Products.Commands.UpdateProduct;
using Products_API.Application.Products.CreateProduct;
using Products_API.Application.Products.Queries.GetAllProducts;
using Products_API.Application.Products.Queries.GetProductById;
using Products_API.Application.Specifications.Commands.AddSpecificationsToProduct;
using Products_API.Application.Specifications.Commands.RemoveSpecificationsFromProduct;
using Products_API.Presentation.Product.DTOs;

namespace Products_API.Presentation.Product;

public class ProductModule : CarterModule
{
    public ProductModule() : base("/products")
    {
        
    }
    
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/", async (CreateProductRequest request, ISender sender) =>
        {
            CreateProductCommand command = request.ToCreateProductCommand();

            var result = await sender.Send(command);

            return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Error);
        });

        app.MapGet("/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            GetProductByIdQuery query = new GetProductByIdQuery(id);

            var response = await sender.Send(query, cancellationToken);

            return response.IsSuccess ? Results.Ok(response.Value) : Results.BadRequest(response.Error);
        });
        
        app.MapGet("/all", async (ISender sender, CancellationToken cancellationToken) =>
        {
            GetAllProductsQuery query = new GetAllProductsQuery();

            var response = await sender.Send(query, cancellationToken);

            return response.IsSuccess ? Results.Ok(response.Value) : Results.BadRequest(response.Error);
        });
        
        app.MapDelete("/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            DeleteProductCommand command = new DeleteProductCommand(id);

            var response = await sender.Send(command, cancellationToken);

            return response.IsSuccess ? Results.Ok() : Results.BadRequest(response.Error);
        });
        
        app.MapPut("/{id}", async (Guid id, UpdateProductRequest request, ISender sender, CancellationToken cancellationToken) =>
        {
            UpdateProductCommand command = new UpdateProductCommand(
                id,
                request.NewName,
                request.NewPrice,
                request.NewQuantity
            );

            var response = await sender.Send(command, cancellationToken);

            return response.IsSuccess ? Results.Ok() : Results.BadRequest(response.Error);
        });

        app.MapPost("/{id}/specifications/add", async (Guid id, AddSpecificationsToProductRequest request, ISender sender, CancellationToken cancellationToken) =>
        {
            AddSpecificationsToProductCommand command = new AddSpecificationsToProductCommand(
                id,
                request.Specifications
            );
            
            var response = await sender.Send(command, cancellationToken);

            return response.IsSuccess ? Results.Ok() : Results.BadRequest(response.Error);
        });
        
        app.MapPost("/{id}/specifications/remove", async (Guid id, RemoveSpecificationsFromProductRequest request, ISender sender, CancellationToken cancellationToken) =>
        {
            RemoveSpecificationsFromProductCommand command = new RemoveSpecificationsFromProductCommand(
                id,
                request.SpecificationTitles
            );
            
            var response = await sender.Send(command, cancellationToken);

            return response.IsSuccess ? Results.Ok() : Results.BadRequest(response.Error);
        });
    }    
}