using System.Text.Json.Serialization;
using Users_API.Application.Users.Commands.CreateUser;

namespace Users_API.Presentation.User.DTOs;

public class CreateUserRequest
{
    [JsonPropertyName("shortName")]
    public string ShortName { get; set; } = string.Empty;

    [JsonPropertyName("longName")]
    public string? LongName { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("age")]
    public int Age { get; set; }

    public CreateUserCommand ToCreateUserCommand()
    {
        CreateUserCommand createUserCommand = new CreateUserCommand(
            ShortName, LongName, Description, Age
        );

        return createUserCommand;
    }
}