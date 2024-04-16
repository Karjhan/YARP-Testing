using System.Text.Json.Serialization;

namespace Products_API.Presentation.Product.DTOs;

public class RemoveSpecificationsFromProductRequest
{
    [JsonPropertyName("specificationTitles")]
    public List<string> SpecificationTitles { get; set; } = new List<string>();
}