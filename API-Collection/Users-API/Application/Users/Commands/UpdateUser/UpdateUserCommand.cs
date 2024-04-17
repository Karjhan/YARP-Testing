using Reports_API.Application.Abstractions;

namespace Users_API.Application.Users.Commands.UpdateUser;

public sealed record UpdateUserCommand(
    Guid UserId,
    string NewShortName,
    string? NewLongName,
    string NewDescription,
    int NewAge
) : ICommand;