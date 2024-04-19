using AutoMapper;
using Commons.Exceptions;
using Commons.Primitives;
using Reports_API.Application.Abstractions;
using Users_API.Application.Users.DTOs;
using Users_API.Domain.Abstractions;
using Users_API.Domain.Entities;

namespace Users_API.Application.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler(IUserRepository userRepository, IMapper _mapper) : IQueryHandler<GetUserByIdQuery, UserResponse>
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

        var response = _mapper.Map<User, UserResponse>(user);
        return response;
    }
}