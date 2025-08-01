using PTR.Mongo.WebApp.Data;
using PTR.Mongo.WebApp.Entities;
using PTR.Mongo.WebApp.Models.Dtos.Requests;

namespace PTR.Mongo.WebApp.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RestaurantApiContext context) : base(context) { }

        public bool CheckIfUserExists(int userId)
        {
            return _context.Users.Any(u => u.Id == userId);
        }

        public User? ValidateUser(AuthenticationRequestDto authRequestBody)
        {
            return _context.Users.FirstOrDefault
                (x => x.RestaurantName == authRequestBody.RestaurantName
                && x.Password == authRequestBody.Password);
        }
    }
}
