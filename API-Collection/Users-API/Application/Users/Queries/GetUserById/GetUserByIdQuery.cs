using Users_API.Application.Abstractions;
using Users_API.Application.Users.DTOs;

namespace Users_API.Application.Users.Queries.GetUserById;

public sealed record GetUserByIdQuery(Guid UserId) : IQuery<UserResponse>
{
    
}