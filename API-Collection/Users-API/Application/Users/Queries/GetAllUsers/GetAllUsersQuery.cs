using Reports_API.Application.Abstractions;
using Users_API.Application.Users.DTOs;

namespace Users_API.Application.Users.Queries.GetAllUsers;

public sealed record GetAllUsersQuery : IQuery<IEnumerable<UserResponse>>
{
    
}