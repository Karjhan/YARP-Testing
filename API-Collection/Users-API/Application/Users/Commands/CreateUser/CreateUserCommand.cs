using Users_API.Application.Abstractions;

namespace Users_API.Application.Users.Commands.CreateUser;

public sealed record CreateUserCommand(
    string ShortName,
    string? LongName,
    string? Description,
    int Age
) : ICommand;