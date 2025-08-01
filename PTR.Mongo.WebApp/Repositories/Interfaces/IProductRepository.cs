using PTR.Mongo.WebApp.Entities;

namespace PTR.Mongo.WebApp.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAllByUserId(int userId);
        Product? GetByProductId(int productId);
        Product Create(Product product);
        void Delete(int id);
    }
}
