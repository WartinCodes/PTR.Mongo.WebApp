using System.Collections.Generic;

namespace PTR.Mongo.WebApp.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
        T Create(T entity);
        void Update(T entity, int id);
        void Delete(int id);
    }
}