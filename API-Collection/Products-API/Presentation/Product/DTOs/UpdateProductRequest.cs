using System.Text.Json.Serialization;

namespace Products_API.Presentation.Product.DTOs;

public class UpdateProductRequest
{
    [JsonPropertyName("name")]
    public string NewName { get; set; } = string.Empty;

    [JsonPropertyName("price")]
    public decimal NewPrice { get; set; }

    [JsonPropertyName("quantity")]
    public int NewQuantity { get; set; }
}