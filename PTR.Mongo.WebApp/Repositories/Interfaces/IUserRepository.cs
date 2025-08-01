using PTR.Mongo.WebApp.Entities;
using PTR.Mongo.WebApp.Models.Dtos.Requests;
using PTR.Mongo.WebApp.Repositories.Interfaces;

public interface IUserRepository : IRepository<User>
{
    bool CheckIfUserExists(int userId);
    User? ValidateUser(AuthenticationRequestDto authRequestBody);
}