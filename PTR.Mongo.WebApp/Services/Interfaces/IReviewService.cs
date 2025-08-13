using PTR.Mongo.WebApp.Entities;
using PTR.Mongo.WebApp.Models.Dtos.Requests;

namespace PTR.Mongo.WebApp.Services.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetAllAsync(string fieldName, string fieldValue);
        Task<Review?> GetByIdAsync(string id);
        Task AddAsync(CreateReviewRequest review);
        Task<bool> UpdateAsync(Review review, string id);
        Task DeleteAsync(string id);
        Task<IEnumerable<Review>> SearchByAuthorAsync(string partialName);
    }
}