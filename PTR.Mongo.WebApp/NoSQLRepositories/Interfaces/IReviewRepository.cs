using PTR.Mongo.WebApp.Entities;

namespace PTR.Mongo.WebApp.NoSQLRepositories.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> FindAsync(string fieldName, string fieldValue);
        Task<Review?> FindByIdAsync(string id);
        Task AddAsync(Review document);
        Task<bool> UpdateAsync(Review document, string id);
        Task DeleteAsync(string id);
        Task<IEnumerable<Review>> SearchByAuthorAsync(string partialName);
    }
}