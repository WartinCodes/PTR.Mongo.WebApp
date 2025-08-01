using Microsoft.EntityFrameworkCore;
using PTR.Mongo.WebApp.Data;
using PTR.Mongo.WebApp.Repositories.Interfaces;

namespace PTR.Mongo.WebApp.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly RestaurantApiContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(RestaurantApiContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll() => _dbSet.ToList();

        public T? GetById(int id) => _dbSet.Find(id);

        public T Create(T entity)
        {
            var added = _dbSet.Add(entity).Entity;
            _context.SaveChanges();
            return added;
        }

        public void Update(T entity, int id)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity is null)
                throw new Exception($"{typeof(T).Name} con id {id} no existe");

            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
