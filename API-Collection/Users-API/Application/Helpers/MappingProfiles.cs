using AutoMapper;
using Users_API.Application.Users.DTOs;
using Users_API.Domain.Entities;

namespace Users_API.Application.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, UserResponse>()
            .ForMember(
                userResponse => userResponse.Name, 
                options => options
                    .MapFrom(user => user.Name.ToString()));
        
    }
}