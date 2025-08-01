using PTR.Mongo.WebApp.Entities;
using PTR.Mongo.WebApp.Models.Dtos.Requests;
using PTR.Mongo.WebApp.Models.Dtos.Responses;
using AutoMapper;

namespace PTR.Mongo.WebApp.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserRequestDto, User>();
        CreateMap<User, UserResponseDto>();
        // UPDATE
    }
}
