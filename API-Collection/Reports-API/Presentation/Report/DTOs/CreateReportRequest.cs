using System.Text.Json.Serialization;
using Reports_API.Application.Reports.Commands.CreateReport;

namespace Reports_API.Presentation.Report.DTOs;

public class CreateReportRequest
{
    [JsonPropertyName("title")] 
    public string Title { get; set; } = string.Empty;
    
    [JsonPropertyName("description")] 
    public string Description { get; set; } = string.Empty;
    
    public CreateReportCommand ToCreateReportCommand()
    {
        CreateReportCommand createReportCommand = new CreateReportCommand(
            Title, Description
        );

        return createReportCommand;
    }
}