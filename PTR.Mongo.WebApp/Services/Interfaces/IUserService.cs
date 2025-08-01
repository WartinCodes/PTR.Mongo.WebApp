using PTR.Mongo.WebApp.Models.Dtos.Requests;
using PTR.Mongo.WebApp.Models.Dtos.Responses;

namespace PTR.Mongo.WebApp.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserResponseDto> GetAll();
        UserResponseDto GetById(int id);
        UserResponseDto CreateUser(CreateUserRequestDto request);
        Task<UserResponseDto> Authenticate(AuthenticationRequestDto request);
        void DeleteUser(int id);
    }
}
