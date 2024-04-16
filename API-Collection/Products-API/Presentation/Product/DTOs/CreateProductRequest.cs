using System.Text.Json.Serialization;
using Products_API.Application.Products.CreateProduct;
using Products_API.Application.Specifications.DTOs;

namespace Products_API.Presentation.Product.DTOs;

public class CreateProductRequest
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("specifications")]
    public List<SpecificationResponse> Specifications { get; set; } = new List<SpecificationResponse>();
    
    public CreateProductCommand ToCreateProductCommand()
    {
        CreateProductCommand createProductCommand = new CreateProductCommand(
            Name, Price, Quantity, Specifications
        );

        return createProductCommand;
    }
}