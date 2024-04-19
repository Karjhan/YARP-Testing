using AutoMapper;
using Commons.Primitives;
using Reports_API.Application.Abstractions;
using Users_API.Application.Users.DTOs;
using Users_API.Domain.Abstractions;
using Users_API.Domain.Entities;

namespace Users_API.Application.Users.Queries.GetAllUsers;

public class GetAllUsersQueryHandler(IUserRepository userRepository, IMapper _mapper) : IQueryHandler<GetAllUsersQuery, IEnumerable<UserResponse>>
{
    public async Task<Result<IEnumerable<UserResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var allUsers = await userRepository.GetAllAsync(cancellationToken);

        var response = _mapper.Map<IEnumerable<User>, IEnumerable<UserResponse>>(allUsers);

        return Result.Success(response);
    }
}