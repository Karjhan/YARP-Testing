using Reports_API.Application.Abstractions;

namespace Users_API.Application.Users.Commands.DeleteUser;

public sealed record DeleteUserCommand(Guid UserId) : ICommand;