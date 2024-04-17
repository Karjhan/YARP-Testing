using Commons.Exceptions;
using Commons.Primitives;
using Reports_API.Application.Abstractions;
using Users_API.Application.Users.DTOs;
using Users_API.Domain.Abstractions;

namespace Users_API.Application.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler(IUserRepository userRepository) : IQueryHandler<GetUserByIdQuery, UserResponse>
{
    public async Task<Result<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            return Result.Failure<UserResponse>(new Error(
                "Member.NotFound",
                $"The member with Id {request.UserId} was not found"
            ));
        }

        var response = new UserResponse(user.Id, user.Name.ToString());
        return response;
    }
}