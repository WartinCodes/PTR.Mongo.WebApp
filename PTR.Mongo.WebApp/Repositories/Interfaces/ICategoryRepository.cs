using PTR.Mongo.WebApp.Entities;

namespace PTR.Mongo.WebApp.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllByUserId(int userId);
        Category Create(Category newCategory);
        void Delete(int id);
    }
}