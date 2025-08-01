using Microsoft.EntityFrameworkCore;
using PTR.Mongo.WebApp.Data;
using PTR.Mongo.WebApp.Entities;
using PTR.Mongo.WebApp.Repositories.Implementations;
using PTR.Mongo.WebApp.Repositories.Interfaces;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(RestaurantApiContext context) : base(context) { }

    public IEnumerable<Category> GetAllByUserId(int userId)
    {
        return _context.Categories.Where(x => x.UserId == userId).ToList();
    }
}