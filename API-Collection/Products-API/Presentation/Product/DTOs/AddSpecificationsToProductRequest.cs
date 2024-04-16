using System.Text.Json.Serialization;
using Products_API.Application.Specifications.DTOs;

namespace Products_API.Presentation.Product.DTOs;

public class AddSpecificationsToProductRequest
{
    [JsonPropertyName("specifications")]
    public List<SpecificationResponse> Specifications { get; set; } = new List<SpecificationResponse>();
}