using AutoMapper;
using PTR.Mongo.WebApp.Entities;
using PTR.Mongo.WebApp.Models.Dtos.Requests;
using PTR.Mongo.WebApp.NoSQLRepositories.Interfaces;
using PTR.Mongo.WebApp.Services.Interfaces;

namespace PTR.Mongo.WebApp.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Review>> GetAllAsync(string fieldName, string fieldValue)
        {
            return await _reviewRepository.FindAsync(fieldName, fieldValue);
        }

        public async Task<Review?> GetByIdAsync(string id)
        {
            return await _reviewRepository.FindByIdAsync(id);
        }

        public async Task AddAsync(CreateReviewRequest review)
        {
            Review newReview = _mapper.Map<Review>(review);
            await _reviewRepository.AddAsync(newReview);
        }

        public async Task<bool> UpdateAsync(Review review, string id)
        {
            return await _reviewRepository.UpdateAsync(review, id);
        }

        public async Task DeleteAsync(string id)
        {
            await _reviewRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Review>> SearchByAuthorAsync(string partialName)
        {
            return await _reviewRepository.SearchByAuthorAsync(partialName);
        }
    }
}
