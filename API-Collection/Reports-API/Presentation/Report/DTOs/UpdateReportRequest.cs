using System.Text.Json.Serialization;

namespace Reports_API.Presentation.Report.DTOs;

public class UpdateReportRequest
{
    [JsonPropertyName("title")] 
    public string NewTitle { get; set; } = string.Empty;
    
    [JsonPropertyName("description")] 
    public string NewDescription { get; set; } = string.Empty;
}