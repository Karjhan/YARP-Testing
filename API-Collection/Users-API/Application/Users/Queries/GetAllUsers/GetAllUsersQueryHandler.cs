using Commons.Primitives;
using Users_API.Application.Abstractions;
using Users_API.Application.Users.DTOs;
using Users_API.Domain.Abstractions;
using Users_API.Domain.Primitives;

namespace Users_API.Application.Users.Queries.GetAllUsers;

public class GetAllUsersQueryHandler(IUserRepository userRepository) : IQueryHandler<GetAllUsersQuery, IEnumerable<UserResponse>>
{
    public async Task<Result<IEnumerable<UserResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var allUsers = await userRepository.GetAllAsync(cancellationToken);

        var response = allUsers.Select(user => new UserResponse(user.Id, user.Name.ToString()));

        return Result.Success(response);
    }
}