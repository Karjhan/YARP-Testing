using System.Text.Json.Serialization;

namespace Users_API.Presentation.User.DTOs;

public class UpdateUserRequest
{
    [JsonPropertyName("shortName")]
    public string NewShortName { get; set; } = string.Empty;

    [JsonPropertyName("longName")]
    public string? NewLongName { get; set; }

    [JsonPropertyName("description")]
    public string NewDescription { get; set; } = string.Empty;

    [JsonPropertyName("age")]
    public int NewAge { get; set; }
}